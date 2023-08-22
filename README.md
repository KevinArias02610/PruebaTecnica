
# Prueba técnica .Net

Documentación prueba técnica de desarrollador .Net, en el cual trabajeremos una API de servicios para la gestión de libros y autores documentada en Swagger e integrada por un segundo proyecto .Net MVC.
## Base de datos
👩‍💻 	Oracle Database 19c Enterprise Edition Release 19.0.0.0.0 – Production

	Creamos una instancia local de base de datos, la cual va a manejar 3 tablas, “Authors” en donde manejaremos la información correspondiente de los autores, “Books” en donde manejaremos la información correspondiente de los libros e “Inventory”, donde manejaremos la cantidad máxima de libros que podremos registrar en nuestro sistema.
### tablas
📦 Authors: 

CREATE TABLE "JULIAN"."AUTHORS" 
   (	"ID" NUMBER DEFAULT "JULIAN"."AUTHORS_SEQ"."NEXTVAL", 
	"FULL_NAME" VARCHAR2(255), 
	"DATE_OF_BIRTH" DATE, 
	"CITY_OF_ORIGIN" VARCHAR2(255), 
	"EMAIL" VARCHAR2(255)
   ) ;

📦 Books: 

CREATE TABLE "JULIAN"."BOOKS"
 (	"ID" NUMBER DEFAULT "JULIAN"."BOOKS_SEQ"."NEXTVAL", 
"TITLE" VARCHAR2(255 BYTE), 
"YEAR" NUMBER, 
"GENRE" VARCHAR2(100 BYTE), 
"NUMBER_OF_PAGES" NUMBER, 
"AUTHOR_ID" NUMBER
)

📦 Inventory: 

CREATE TABLE "JULIAN"."INVENTORY"
 (	"ID" NUMBER(*,0), 
"NUMBER_OF_RECORDS" NUMBER(*,0)
)






## API Reference Proyecto 1
![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/8a91b58b-8351-4370-87bc-98d4352b96be)

#### Authors

```http
  GET /Authors/GetAllAuthors
```
```http
  GET /Authors/GetAuthorById
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id` | `int32` | **Required**. Id del autor |

```http
  POST /Authors/RegisterAuthor
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `fullName` | `string` | **Required**. Nombre completo |
| `dateOfBirth` | `string` | **Required**. Fecha de nacimiento |
| `cityOfOrigin` | `string` | **Required**. Ciudad de procedencia |
| `email` | `string` | **Required**. correo electrónico |

#### Books

```http
  GET /Books/GetAllBooks
```

```http
  POST /Books/RegisterBook
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `authorFullName` | `string` | **Required**. Autor |
| `bookTitle` | `string` | **Required**. Titulo |
| `bookYear` | `int` | **Required**. Año |
| `bookGenre` | `string` | **Required**. Género |
| `bookNumberOfPages` | `int` | **Required**. Número de páginas |

#### Inventory

```http
  GET /Inventory/GetNumberOfRecords
```
```http
  POST /Books/RegisterBook
```
| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Numero` | `int` | **Required**. Número de registros |

## Frontend Proyecto 2

#### Home

	Consumimos el servicio "GetAllBooks" para mostrar.
![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/b3d9de15-641f-48b4-9bb0-71c0b4438bab)
#### Registrar libros
	Nos dirigimos a la vista de "Registrar libro" en donde vamos a rellenar los campos del formulario de registro; en caso de que el autor que ingresemos no esté registrado aparecerá la alerta
 ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/0cedee4a-1d61-431f-9e77-73c9e1603ef0)

 	En caso de que el titulo del libro ya se encuentre registrado nos mostrará la alerta:
  ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/55296e60-4afd-467c-b3b7-ac9d21b3d036)
  
	En caso de que agregemos un libro que no cumpla con las anteriores excepciones:
  ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/99ec5a18-7326-41ec-b906-b5ca08227cc1)

	Consultamos en la tabla que el registro se haya creado correctamente
  ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/83175c6a-f700-47ba-a565-2f65b04cf5c4)
  
#### Registrar autores
	Nos dirigimos a la vista "Registrar Autor" en donde rellenaremos los campos que nos pide el formulario.
  ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/c3a6d69c-3adf-406e-bd86-0d8a6e9aca4a)

	Nos generará la alerta en caso de que se haya creado correctamente.
  ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/168c84e3-9416-4df7-a0b4-cac564051a2a)

	Ya que se garantiza la integridad de la información debemos dirigirnos a base de datos para corroborar que el autor si quedó registrado correctamente.
  ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/b73e4cf4-7890-4a9f-aa99-27cacc3003f2)

#### Máximo permitido
	Nos dirigimos a la vista "Máximo permitido", en donde se desplegará un formulario con la cantidad máxima actual que tenemos definida, el cual podremos modificar, en este caso son 10 registros.
 ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/ebb47f05-8cf5-48e9-822d-3d0b84754583)

	Ya que actualmente tenemos 7 libros registrados, vamos a modificar la cantidad máxima a 7, esto quiere decir que si intentamos registrar un nuevo libro no lo deberia permitir.
 ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/b371d213-9080-48dd-ab51-8660f5f60dc0)

	Nos dirigimos a la vista "Registrar libro" e intentamos hacer un nuevo registro, debería generarnos el mensaje de No es posible registrar el libro, se alcanzó el máximo permitido".
 ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/8aa3ffbf-d7dd-42b7-b63e-f7d6efc8a64c)


## 🛠 Estructura del proyecto
![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/beb62515-d17e-43d1-96d8-103b7b7554a4)

- PruebaTecnicaAPI: 
	En esta capa tendremos los controladores para Authors, Books e Inventory, adicionalmente tendemos la clase de registro de interfaces de negocio y servicios..

  ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/a85b4129-0cbe-48a2-9ef0-0ce1b468648b)


- PruebaTecnicaBusiness:
  En esta capa tendremos toda la logica del sistema de información, adicionalmente las interfaces que utilizaremos para ello.

  ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/0076ddd2-fe87-4b2d-9679-05e71c2c1a90)

- PruebaTecnicaDataAccess
  En esta capa tenemos nuestro contexto de base de datos el cual generamos ejecutando un comando scaffold, el cual nos generó la clase de conexión y modelos de base de datos.

  ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/dfffe243-408b-48ac-b614-63767622dac6)

- PruebaTecnicaDTOs
  En esta capa tendremos todos los objetos de transferencia de datos o modelos, los cuales usaremos en cada contexto dependiendo de las acciones.
  
  ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/fa50c714-1502-4f77-981f-e40cd951a7e4)

- PruebaTecnicaServices
  En esta clase tendremos los servicios que utilizaremos para integrar en nuestra capa de negocio, adicionalmente las interfaces que implementa.

  ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/841e44f7-c994-4969-a172-1dea59ebe09b)

- PruebaTecnicaFrontend
  En esta capa tenemos todo el desarrollo del proyecto número 2, un proyecto .NET MVC maquetado con bootstrap y KENDO UI, en donde integraremos y consumiremos nuestra API desarrollada en el proyecto 1.
  
  ![image](https://github.com/KevinArias02610/PruebaTecnica/assets/51764533/28eaf2d7-f4ed-4716-b15a-bc94774b5148)

## 🚀 Referencias

	📧 Email: Kjulianr41@gmail.com
	📲 Teléfono: +57 3143291623
