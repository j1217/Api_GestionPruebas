using Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Aspirante> Aspirantes { get; set; }
    public DbSet<PruebaSeleccion> PruebasSeleccion { get; set; }
    public DbSet<Pregunta> Preguntas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    // Método para ejecutar procedimientos almacenados
    public async Task<IEnumerable<T>> ExecuteStoredProcedureAsync<T>(string storedProcedureName, params DbParameter[] parameters)
    {
        var commandText = $"EXEC {storedProcedureName} {string.Join(", ", parameters.Select(p => $"@{p.ParameterName}"))}";

        var result = new List<T>();

        using (var command = Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = commandText;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters);

            if (command.Connection.State == ConnectionState.Closed)
                await command.Connection.OpenAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    var item = reader.GetFieldValue<T>(0);
                    result.Add(item);
                }
            }
        }

        return result;
    }

    // Método para exportar el reporte por aspirante a un archivo CSV
    public async Task ExportarReportePorAspiranteCSVAsync(int aspiranteId)
    {
        var parameters = new DbParameter[] { new SqlParameter("@AspiranteID", aspiranteId) };

        var reporte = await ExecuteStoredProcedureAsync<ReporteAspirantes>("ObtenerReportePorAspirante", parameters);

        EscribirCSV(reporte);
    }

    // Método para obtener el reporte para todos los aspirantes y escribirlo en un archivo CSV
    public async Task ExportarReporteParaTodosAspirantesCSVAsync()
    {
        var reporte = await ExecuteStoredProcedureAsync<ReporteAspirantes>("ObtenerReporteParaTodosAspirantes");

        EscribirCSV(reporte);
    }    

    // Método genérico para escribir en un archivo CSV
    private void EscribirCSV<T>(IEnumerable<T> data)
    {
        // Convertir el resultado a un formato CSV
        var csvContent = new StringBuilder();
        var properties = typeof(T).GetProperties();

        string filePath = "";

        csvContent.AppendLine(string.Join(",", properties.Select(p => p.Name)));

        foreach (var item in data)
        {
            csvContent.AppendLine(string.Join(",", properties.Select(p => p.GetValue(item)?.ToString() ?? "")));
        }

        // Escribir el contenido CSV en el archivo
        File.WriteAllText(filePath, csvContent.ToString());
    }

    
}


