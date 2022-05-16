Entity Framework Core Commands for Migrations

    Documentación: https://www.entityframeworktutorial.net/efcore/cli-commands-for-ef-core-migration.aspx
    Agregar migración: dotnet ef migrations add Initial
    Actualizar base de datos: dotnet ef database update
    Listar migraciones: dotnet ef migrations list
    Script de migración: dotnet ef migrations script
    Remover migración: dotnet ef migrations remove
    Eliminar base de datos: dotnet ef database drop

Paso a paso para crear una nueva API basada en la API base

    Paso 1: Clonar el proyecto
    Paso 2: Situarse en la rama correspondiente
    Paso 3 (IMPORTANTE): Borrar la carpeta .git (esta oculta) para no commitiar los cambios en el repositorio original
    Paso 4: Renombrar las carpetas Ciudadano.Api y Ciudadano.Api\Ciudadano.Api a un nombre a elección ej: ATI.NombreProyecto.Api
    Paso 5: Renombrar todos las ocurrencias de Ciudadano.Api (en todo el proyecto) al nombre de tu elección ej: ATI.NombreProyecto.Api (sugerencia: usar Visual Code)
    Paso 6: Borrar todas las migraciones existentes
    Paso 7: Crear las clases correspondientes de tu modelo
    Paso 8: Configurar la cadena de conexón a tu base de datos SQL Server en el archivo appsettings.json
    Paso 9: Abrir la consola de Windows PowerShell
    Paso 10: Ejecutar el siguiente comando (SOLO LA PRIMERA VEZ): dotnet tool install --global dotnet-ef
    Paso 11: Agregar la primera migración: dotnet ef migrations add Initial
    Paso 12: Obtener el Script SQL de la migración: dotnet ef migrations script
    Paso 13: Acatualizar la base de datos: dotnet ef database update

Requerimientos para implementar datos espaciales (spatial data)
    - Instalar complemento PostGIS (http://postgis.net/install/) para PostgreSQL (según la versión utilizada) desde aquí http://download.osgeo.org/postgis/windows/

Características pendientes de implementación

    - Seed
    - Integración con Identity Server Authentication
