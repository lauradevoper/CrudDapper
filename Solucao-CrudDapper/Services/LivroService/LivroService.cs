using Dapper;
using Solucao_CrudDapper.Models;
using System.Collections;
using System.Data.SqlClient;

namespace Solucao_CrudDapper.Services.LivroService
{
    public class LivroService : ILivroInterface
    {
        private readonly IConfiguration _configuration;
        private readonly string getConnection;
        public LivroService(IConfiguration configuration)
        {
            _configuration = configuration;
            getConnection = _configuration.GetConnectionString("DefaultConnection");

        }

        public async Task<IEnumerable> CreateLivro(Livro livro)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "insert into Livros (Titulo, Autor) values (@Titulo, @Autor)";
                await con.ExecuteAsync(sql, livro);
                return await con.QueryAsync<Livro>("select * from Livros");
            }
        }

        public async Task<IEnumerable> DeleteLivro(int livroid)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "delete from Livros where id = @Id";
                await con.ExecuteAsync(sql, new { Id = livroid });
                return await con.QueryAsync<Livro>("select * from Livros");
            }
        }

        [Obsolete]
        public async Task<IEnumerable<Livro>> GetAllLivros()
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "select * from Livros";
                return await con.QueryAsync<Livro>(sql);
            }
        }

        public async Task<Livro> GetLivroById(int livroId)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "select * from Livros where id = @Id";
                return await con.QueryFirstOrDefaultAsync<Livro>(sql, new { Id = livroId });
            }
        }

        public async Task<IEnumerable> UpdateLivro(Livro livro)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "update Livros set Titulo = @Titulo, Autor = @Autor where id = @Id";
                await con.ExecuteAsync(sql, livro);
                return await con.QueryAsync<Livro>("select * from Livros");
            }
        }
    }
}
