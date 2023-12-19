﻿using ApiTechRiders.Models;
using ApiTechRiders.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTechRiders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class UsuariosController : ControllerBase
    {
        private RepositoryTechRiders repo;
        public UsuariosController(RepositoryTechRiders repo)
        {
            this.repo = repo;
        }

        // GET: api/usuarios
        /// <summary>
        /// Obtiene el conjunto de USUARIOS, tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Método para devolver todos las USUARIOS de la BBDD
        /// </remarks>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await this.repo.GetUsuarioAsync();
        }

        // GET: api/usuarios/{id}
        /// <summary>
        /// Obtiene un USUARIOS por su Id, tabla USUARIOS.
        /// </summary>
        /// <remarks>
        /// Permite buscar un objeto USUARIOS por su ID
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto USUARIOS.</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Find(int id)
        {
            var user = await this.repo.FindUsuarioAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        // POST: api/usuarios
        /// <summary>
        /// Crea una nueva USUARIOS en la BBDD, tabla USUARIOS
        /// </summary>
        /// <remarks>
        /// Este método inserta un nuevo USUARIOS enviando el Objeto JSON
        /// El ID de la charla se genera automáticamente dentro del método
        /// </remarks>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Usuario>>
            InsertUsuario(Usuario usuarioRequest)
        {
            Usuario usuarioNew =
                await this.repo.InsertUsuarioAsync
                (usuarioRequest);
            return usuarioNew;
        }

        // PUT: api/usuarios
        /// <summary>
        /// Modifica una USUARIOS en la BBDD mediante su ID, tabla USUARIOS
        /// </summary>
        /// <response code="201">Created. Objeto correctamente creado en la BD.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <response code="500">BBDD. No se ha creado el objeto en la BD. Error en la BBDD.</response>/// 
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateUsuario
            (Usuario usuarioRequest)
        {
            var usuarioFind = await this.repo.FindCharlaAsync(usuarioRequest.IdUsuario);
            if (usuarioFind == null)
            {
                return NotFound();
            }
            await this.repo.UpdateUsuarioAsync(usuarioRequest);
            return Ok();
        }

        // DELETE: api/usuarios/{id}
        /// <summary>
        /// Elimina una USUARIOS en la BBDD mediante su ID. Tabla USUARIOS
        /// </summary>
        /// <remarks>
        /// Enviaremos el ID mediante la URL
        /// </remarks>
        /// <param name="id">ID del USUARIOS a eliminar</param>
        /// <response code="201">Deleted. Objeto eliminado en la BBDD.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>    
        /// <response code="500">BBDD. No se ha eliminado el objeto en la BD. Error en la BBDD.</response>/// 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {
            var user = await this.repo.FindUsuarioAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            await this.repo.DeleteUsuarioAsync(id);
            return Ok();
        }
    }
}