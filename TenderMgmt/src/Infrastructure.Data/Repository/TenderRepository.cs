using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.IRepository;
using Domain.Entities;
using System.Linq;

namespace Infrastructue.Data.Repository
{
    public class TenderRepository : ITenderRepository
    {
        private readonly IDbManager _dbManager;

        public TenderRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public async Task<IEnumerable<Tender>> GetAllAsync()
        {
            return await _dbManager.Connection.QueryAsync<Tender>("Select * from Tenders;");
        }

        public async Task<Tender> GetAsyncById(int id)
        {
            var query = @"
                    Select * from Tenders where Id = @Id;
                    Select * from TenderTags where TenderId = @Id;
                ";

            using (var result = await _dbManager.Connection.QueryMultipleAsync(query, new { Id = id }))
            {
                var tender = result.ReadSingleOrDefault<Tender>();
                var tenderTags = result.Read<TenderTag>().ToList();

                if (tender != null)
                {
                    tender.TenderTags = tenderTags;
                }

                return tender;
            }
        }

        public async Task<int> Add(Tender tender)
        {
            using (var transaction = _dbManager.Connection.BeginTransaction())
            {
                try
                {
                    var id = await _dbManager.Connection.ExecuteScalarAsync<int>(@"Insert into Tenders
                                    (Name,  ReferenceNumber, ReleaseDate,ClosingDate, Description, UserId)
                            values  (@Name, @ReferenceNumber, @ReleaseDate,@ClosingDate, @Description,@UserId)
                            SELECT Cast(SCOPE_IDENTITY() as int)",
                                      new
                                      {
                                          Name = tender.Name,
                                          ReferenceNumber = tender.ReferenceNumber,
                                          ReleaseDate = tender.ReleaseDate,
                                          ClosingDate = tender.ClosingDate,
                                          Description = tender.Description,
                                          UserId = tender.UserId
                                      }, transaction);

                    if (tender.TenderTags != null && tender.TenderTags.Any())
                    {
                        foreach (var tenderTag in tender.TenderTags)
                        {
                            var sqlString = "Insert into TenderTags (Name, TenderId) values (@Name, @TenderId);";
                            await _dbManager.Connection.ExecuteAsync(sqlString.ToString(), new { Name = tender.Name, TenderId = id }, transaction);
                        }
                    }

                    transaction.Commit();

                    tender.Id = id;

                    return id;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

    }
}
