﻿using ControlDeHabitos2.API.Models;

namespace ControlDeHabitos2.API.Interfaces
{
    public interface IHabitoRepository
    {
        List<Habito> ObtenerPorUsuarioId(int usuarioId);
        List<Habito> ObtenerTodos();
        Habito? ObtenerPorId(int id);
        void Crear(Habito nuevoHabito);
        void Actualizar(Habito habitoActualizado);
        void Eliminar(int id);
    }
}
