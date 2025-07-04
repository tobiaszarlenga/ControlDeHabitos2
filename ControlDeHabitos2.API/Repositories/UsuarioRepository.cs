﻿using ControlDeHabitos2.API.Data;
using ControlDeHabitos2.API.Interfaces;
using ControlDeHabitos2.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlDeHabitos2.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Agregar(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar usuario", ex); // propaga el error exacto
            }
        }


        public List<Usuario> ObtenerTodos()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario? ObtenerPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public void Eliminar(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
            }
        }

        public Usuario? ObtenerPorCredenciales(string nombre, string contraseña)
        {
            return _context.Usuarios.FirstOrDefault(u =>
                u.Nombre == nombre && u.Contraseña == contraseña);
        }
        public bool ExistePorNombre(string nombre)
        {
            return _context.Usuarios.Any(u => u.Nombre == nombre);
        }

    }
}
