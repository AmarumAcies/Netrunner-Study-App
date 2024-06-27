

using Dapper;
using Netrunner.Domain.Core;
using Netrunner.Domain.Interface;
using System.Data.SqlClient;

namespace Netrunner.Infrastructure.Implementation
{
    public class CardRepository : ICardRepository
    {
        private readonly string _connectionString; //IOptions: GetServices - Json по настройкам
        public CardRepository(string connectionString) //автоматически будет вызываться при создании программы для мини экземпляров, через которые будут обращаться к логике
        {
            _connectionString = connectionString;
        }
        public async Task AddCard(Card card)
        {
            var sql = @"INSERT INTO [Netrunner.Base].[dbo].[Card]
                       (CardId,
                       [Cost],
                       [Name],
                       [PlayerType],
                       [Description])
                 VALUES
                     (
		              @CardId,
                       @Cost,
                       @Name, 
                       @PlayerType,
                       @Description )";

            using (var connection = new SqlConnection(_connectionString))
            {               
                var res = await connection.QueryAsync(sql, card);
            }


        }

        public async Task<Card> GetCardGetById(string cardId)
        {
            var sql = $@"SELECT * 
                        FROM [Netrunner.Base].[dbo].[Card]
                        WHERE [CardId] = @cardId";


            using (var connection = new SqlConnection(_connectionString))
            {
                return (await connection.QueryAsync<Card>(sql, new { cardId })).FirstOrDefault();
            }

           
        }

        public async Task RemoveCard(string cardId)
        {
            var sql = $@"DELETE FROM [Netrunner.Base].[dbo].[Card]
                         WHERE [CardId] = @cardId";

            using (var connection = new SqlConnection(_connectionString))
            {
                var res = await connection.QueryAsync(sql, new {cardId});
            }
        }

        public async Task UpdateCard(Card card)
        {
            var sql = $@"UPDATE [Netrunner.Base].[dbo].[Card] SET
                        [CardId] = @CardId,
                        [Cost] = @Cost,
                        [Name] = @Name,
                        [PlayerType] = @PlayerType,
                        [Description] = @Description
                 
                        WHERE [CardId] = @cardId";

            using (var connection = new SqlConnection(_connectionString))
            {
                var res = await connection.QueryAsync(sql, card);
            }
        }
    }
}
