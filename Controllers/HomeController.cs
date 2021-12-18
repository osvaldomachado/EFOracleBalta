using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Todo.Models
{
    [ApiController]
    //[Route("home")]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IList<Usuario> Buscar([FromServices] AppDbContext context) 
        {        

           // IList<dynamic> lista = new List<dynamic>();

            //var usuarios = context.Usuarios.AsNoTracking().ToList();
            // var setores = context.Setores.AsNoTracking().ToList();

            // var query = from usuario in usuarios
            //             join setor in setores
            //             on usuario.CODSETOR equals setor.CODSETOR 
            //             select new
            //             {
            //                 Matricula = usuario.MATRICULA,
            //                 Nome = usuario.NOME,
            //                 CodSetor = usuario.CODSETOR,
            //                 Setor = setor.DESCRICAO                                    
            //             };
           
            // foreach (var item in query)
            // {
            //     dynamic itemLista = new
            //     {
            //         Matricula = item.Matricula,
            //         Nome = item.Nome,
            //         CodSetor = item.CodSetor,
            //         Setor = item.Setor
            //     };

            //     lista.Add(itemLista);
            // }

            // return lista;

            return context.Usuarios.AsNoTracking().ToList();
        }

        [HttpGet("/{MATRICULA:int}")]
        public Usuario BuscarPorMatricula([FromRoute] int MATRICULA, [FromServices] AppDbContext context) 
        { 
            return context.Usuarios.AsNoTracking().FirstOrDefault(x => x.MATRICULA == MATRICULA);            
        }

        [HttpPost("/")]
        public Usuario Inserir([FromBody]Usuario usuario, [FromServices] AppDbContext context) 
        { 
            context.Usuarios.Add(usuario);
            context.SaveChanges();

            return usuario;
        }

        [HttpPut("/{MATRICULA:int}")]
        public Usuario Atualizar(
            [FromRoute] int MATRICULA, 
            [FromBody] Usuario usuarioAtualizado,
            [FromServices] AppDbContext context ) 
        { 
            var usuario = context.Usuarios.FirstOrDefault(x => x.MATRICULA == MATRICULA);  

            if(usuario !=null && usuario.MATRICULA > 0) 
            {
                usuario.NOME = usuarioAtualizado.NOME;
                context.Usuarios.Update(usuario);
                context.SaveChanges();                
            }

            return usuario;            
        }

        [HttpDelete("/{MATRICULA:int}")]
        public Usuario Apagar(
            [FromRoute] int MATRICULA, 
            [FromServices] AppDbContext context ) 
        { 
            var usuario = context.Usuarios.FirstOrDefault(x => x.MATRICULA == MATRICULA);  

            if(usuario !=null && usuario.MATRICULA > 0) 
            {                
                context.Usuarios.Remove(usuario);
                context.SaveChanges();                
            }

            return usuario;            
        }
    }
}