# Aplicación Web usando Web Service enlazado a una BD Oracle.

El siguiente proyecto tiene como fin crear una BD en Oracle 11g, vincularla a un Web Service y finalmente consumir el mismo desde una aplicación Web.

**Nota: Los archivos del repositorio no contienen en su totalidad el proyecto, solo archivos importantes con su explicación para que funcione correctamente.**

## Comenzando

Para el proyecto utilizamos una BD llamada transporteBD. Transporte controla desde las compras de boletos, hasta la llegada a destinos. De igual manera estaremos subiendo el script de la creación de la BD así como también como se pobló la data.

Para la realización del Web Service, usamos Visual Studio 2019, utilizando el lenguaje C#, llamando a distintos procedimientos creados en la BD. 

Finalmente, utilizamos Android Studio, para poder crear nuestra aplicación Android.

### Pre-requisitos 📋

* Oracle 11g. 
* Visual Studio 2019
  - ODAC for Visual Studio 2019: Nos agrega una referencia para poder utlizar todos los comandos que Oracle tiene para su manejo en Visual Studio
    - https://docs.microsoft.com/en-us/visualstudio/releases/2019/release-notes
  - Package Newtonsoft.Json: Al crear un Web Service vemos que nos retorna código .xml, si nosotros consideramos mejor manejable el formato JSON, tenemos esta referencia del Visual para poder retornar un string JSON.
    - https://www.c-sharpcorner.com/UploadFile/ansh06031982/creating-web-services-in-net-which-returns-xml-and-json-dat/
## Autores 

El proyecto se realizó como proyecto final del curso de Procesos de Software en la Universidad La Salle - Arequipa.

* **Walther Medina** - *Alumno VI Ciclo, Universidad La Salle - Arequipa* - 
