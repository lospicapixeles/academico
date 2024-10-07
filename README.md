## 🎓 Sistema Académico - PicaPixeles 🌴
![Principal](https://i.ibb.co/C0HN27b/Captura-de-pantalla-2024-10-07-a-la-s-10-15-31-a-m.png)

Sistema académico desarrollado en .NET con base de datos alojada en Somee, que permite la gestión de usuarios, cursos y calificaciones de una institución educativa. Es ideal para estudiantes, profesores y administradores que necesitan una herramienta eficiente para manejar los procesos académicos.

#### 📋 Características
- Gestión de usuarios (Estudiantes, Profesores, Administradores)
- Módulo de cursos: Creación y asignación de cursos.
- Registro de calificaciones: Fácil acceso y registro de notas.
- Interfaz de usuario intuitiva y responsiva.
#### 🚀 Instalación y Configuración
Requisitos previos
- .NET SDK (versión 6.0 o superior)
- SQL Server o base de datos compatible (puedes instalarla localmente)
- Base de datos Somee o tu propia instalación local.

#### Instrucciones
1. Clona este repositorio:

```bash
git clone https://github.com/lospicapixeles/academico.git
```
2. Configura la base de datos:

- Puedes usar el servidor de Somee o configurarlo localmente.
- Los detalles de acceso para la base de datos están en el archivo Web.Config.
Credenciales base de datos (si instalas localmente):

- Usuario: admin
- Contraseña: 1234

#### ⚙️ Uso
- Inicio de sesión: Usa las credenciales proporcionadas para acceder como administrador:
  - Usuario: admin
  - Contraseña: 1234

Una vez dentro, podrás gestionar las funciones del sistema académico.

#### 🛠 Estructura del Proyecto
El proyecto sigue la arquitectura básica de una aplicación ASP.NET con los siguientes directorios clave:

- Capa Negocio: Lógica de negocio donde se define las clases con atributos y metodos de la base de datos.
- Capa Presentación: El diseño de la aplicacion (HTML) con funcionalidad referenciando a la Capa de Negocio.

#### 🎨 Capturas de Pantalla
![Inicio](https://i.ibb.co/gjxGhRs/Captura-de-pantalla-2024-10-07-a-la-s-10-11-07-a-m.png)

![Login](https://i.ibb.co/2dyVNP0/Captura-de-pantalla-2024-10-07-a-la-s-10-13-48-a-m.png)

#### 🤝 Contribuciones
Las contribuciones son bienvenidas. Si deseas mejorar alguna funcionalidad o reportar un problema, siéntete libre de abrir un issue o crear un pull request.
#### 📄 Licencia
Este proyecto está bajo la Licencia MIT. Mira el archivo LICENSE para más detalles.

