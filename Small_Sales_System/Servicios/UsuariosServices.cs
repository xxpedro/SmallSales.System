using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Small_Sales_System.Herramientas;
using Small_Sales_System.Models;
using Small_Sales_System.Models.Request;
using Small_Sales_System.Models.Response;
using Small_Sales_System.Models.ViewModel;
using Small_Sales_System.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Small_Sales_System.Servicios
{
    public class UsuariosServices : IUsuariosServices
    {

        private readonly AppSettings appSettings;

        public UsuariosServices(IOptions<AppSettings> appSetting)
        {
            appSettings = appSetting.Value;
        }

        public UsuarioResponse Logueo(AutenticarRQ model)
        {
            UsuarioResponse ObjUsuarios = new UsuarioResponse();

            using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
            {
                string EncriptPss = EncriptarPass.GetSHA256(model.clave);

                var Usuario = (from d in db.Usuarios
                               where d.Clave == EncriptPss && d.Correo == model.Correo
                               select d).FirstOrDefault();

                if (Usuario != null)
                {
                    ObjUsuarios.Email = Usuario.Correo;
                    ObjUsuarios.Token = GenerarToken(Usuario);
                }
                else 
                {
                    return null;
                }
            }
            return ObjUsuarios;
        }
        private string GenerarToken(Usuarios usuarios) 
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                (
                  new Claim[]
                  {
                     new Claim(ClaimTypes.NameIdentifier,usuarios.Id.ToString()),
                     new Claim(ClaimTypes.Email, usuarios.Correo)
                  }
                ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256)
            };


            var Token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(Token);

        }
        public List<Usuarios> Listar() 
        {
            List<Usuarios> lista;
            using ( Small_Sales_SystemContext db = new Small_Sales_SystemContext()) 
            {
               lista = db.Usuarios.ToList();
            }
            
            return lista;
        }
        public List<Usuarios> ListarID(int id)
        {
            List<Usuarios> listado;
            using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
            {
                listado = db.Usuarios.Where(x => x.Id == id).ToList();
            }
            return listado;
        }
        public void Create(UsuariosViewModel model)
        {
            using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
            {
                Usuarios usuarios = new Usuarios();
                string EncriptPss = EncriptarPass.GetSHA256(model.Clave);
                usuarios.Nombre = model.Nombre;
                usuarios.Apellido = model.Apellido;
                usuarios.Correo = model.Correo;
                usuarios.Clave = EncriptPss;

                db.Usuarios.Add(usuarios);
                db.SaveChanges();
            }
        }
        public void Editar(int id,UsuariosViewModel model) 
        {
            try
            {
                using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
                {
                    string EncriptPss = EncriptarPass.GetSHA256(model.Clave);
                    var EditarUsuarios = db.Usuarios.Where(x => x.Id == id).FirstOrDefault();
                    EditarUsuarios.Apellido = model.Apellido;
                    EditarUsuarios.Clave = EncriptPss;
                    EditarUsuarios.Correo = model.Correo;
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Eliminar(int id) 
        {
            using (Small_Sales_SystemContext db = new Small_Sales_SystemContext())
            {
                var EliminarUsuario = db.Usuarios.Where(x => x.Id == id).FirstOrDefault();
                db.Usuarios.Remove(EliminarUsuario);
                db.SaveChanges();
            }
        }
    


    }
}
