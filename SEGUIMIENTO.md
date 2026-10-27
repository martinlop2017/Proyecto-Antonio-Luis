# Seguimiento de la renovación — Proyecto Antonio Luis

Lista de todos los formularios del programa. Cuando un formulario está
reparado **y probado**, se tacha (~~así~~) y se marca con ✅.

Estados:
- ⬜ Pendiente de revisar
- 🔧 Modificado, **pendiente de probar** en Visual Studio
- ✅ Reparado y probado
- 🗑️ No se usa (candidato a borrar)

Última actualización: 28-10-2026 (Cliente, MisDatos, Impuestos y Backup terminados; acordado cambio de año sin borrar)

---

## 1. Entrada al programa

| Estado | Formulario | Qué hace | Notas |
|:-:|---|---|---|
| ⬜ | Control Usuarios (`Form1`) | Pantalla de login | Cambiado el marco el 26-10 (commit de Martín). **Busca el logo en la ruta antigua: cambiarlo para que use el logo guardado en la tabla Propios** |
| ⬜ | preguntaseguridad | Pregunta de seguridad al olvidar la contraseña | |
| ⬜ | Nuevacontraseña | Cambiar la contraseña | |
| ⬜ | MenuPrincipal | Menú principal | Los botones Listados, Agenda y Ayuda no hacen nada todavía |

## 2. Clientes

| Estado | Formulario | Qué hace | Notas |
|:-:|---|---|---|
| 🔧 | GestionClientes | Lista de clientes: alta, modificar, eliminar | Recodificado 26-10. Clientes de baja en gris. Eliminar con avisos |
| ✅ | ~~Cliente~~ | ~~Ficha del cliente (alta y modificación)~~ | ~~Recodificado 26-10. Campos ampliados, validaciones, baja/reactivación. 27-10: IBAN en un solo campo (hasta 34)~~ Probado 27-10. Sin domiciliación el IBAN queda en gris; tabulación ordenada |
| 🔧 | GestionDocumentos | Documentos del cliente / escáner | Solo cambiada la ruta de la carpeta del cliente (26-10) |

## 3. Facturación

| Estado | Formulario | Qué hace | Notas |
|:-:|---|---|---|
| 🔧 | Facturacion | Facturación mensual | 26-10: ruta de los PDF. 27-10: IBAN completo; arreglado "añadir cliente a mano" (leía columnas desplazadas). Revisar entero |
| ⬜ | GestionFacturas | Lista de facturas | |
| 🔧 | FacturaUnitaria | Factura manual | 27-10: guarda el IBAN completo. Sigue con 6 cuadros para el IBAN escrito a mano. Busca el cliente por nombre exacto |
| ⬜ | ImprimirFacturas | Imprimir un rango de facturas | |
| ⬜ | Form3 | Exporta una factura a PDF (interno) | Nombre poco claro |
| ⬜ | Form4 | Impresión directa (interno) | Nombre poco claro |
| ⬜ | Form2 | Visor de listados de remesas (interno) | Nombre poco claro |

## 4. Bancos y contabilidad

| Estado | Formulario | Qué hace | Notas |
|:-:|---|---|---|
| ⬜ | GestionRemesas | Lista de remesas | |
| 🔧 | CBS19 | Genera la remesa SEPA (XML) | 26-10: nombre del deudor recortado a 70 car. 27-10: IBAN completo (o bloques en facturas antiguas). Revisar formato SEPA actual |
| 🔧 | Contaplus | Exportación a Contaplus | Nombre recortado a 40 car. (26-10) |
| ✅ | ~~Impuestos~~ | ~~Tipos de IVA y retenciones IRPF~~ | ~~Recodificado 27-10: validaciones (coma o punto), confirma al eliminar, no se cae con la lista vacía. Nueva lista de retenciones IRPF y cuál se aplica~~ Probado 27-10 |

## 5. Sistema

| Estado | Formulario | Qué hace | Notas |
|:-:|---|---|---|
| ✅ | ~~MisDatos (Propios)~~ | ~~Datos de la empresa emisora~~ | ~~Recodificado 27-10: IBAN en un campo, identificador SEPA y BIC completos, no se cae sin datos o sin logo, validaciones, tabulación. Logo guardado dentro de la tabla (no la ruta)~~ Probado 27-10 |
| ⬜ | Rutas | Rutas y cuentas contables | |
| ⬜ | GestionUsuarios | Lista de usuarios | |
| ⬜ | Usuario | Ficha de usuario | |
| ✅ | ~~Backup~~ | ~~Copia de seguridad y restauración~~ | ~~Recodificado 28-10: usa la conexión del programa, carpeta de destino elegible, no mete copias dentro de copias, conserva las últimas N, progreso real. Nuevo: Restaurar (con copia previa automática; admite los ZIP antiguos)~~ Probado 28-10 |
| ⬜ | ReiniciaBases | Cierre de año / reinicio de numeración | Servidor SQL escrito a mano (`DESKTOP-UKKKNCG`): solo funciona en ese PC |

## 6. Auxiliares

| Estado | Formulario | Qué hace | Notas |
|:-:|---|---|---|
| ⬜ | FormEsperar | Ventana "Espere..." | |

## 7. Formularios que no se abren desde ningún sitio

Revisar si se pueden borrar.

| Estado | Formulario | Notas |
|:-:|---|---|
| 🗑️ | BORRAR | Ya tiene el nombre puesto |
| 🗑️ | pruebasprogress | Prueba de barra de progreso |
| 🗑️ | SampleRuProgressBar1 | Prueba de barra de progreso |
| 🗑️ | Espera | Sustituido por FormEsperar |
| 🗑️ | GenerarRemesas | Versión antigua de CBS19 (actualizado el IBAN igualmente, 27-10) |
| 🗑️ | Gestionlistados | Listados a medio hacer (¿para el botón Listados?) |
| 🗑️ | correo | Prueba de envío por correo |
| 🗑️ | Scaner | Prueba de escáner |

---

## Cambios en la base de datos

| Estado | Script | Qué hace |
|:-:|---|---|
| 🔧 | `SQL/2026-10-26_Clientes_ampliar_campos.sql` | Amplía campos de Clientes y Facturas, crea la tabla Contadores. Hace copia de seguridad antes |
| 🔧 | `SQL/2026-10-27_IBAN_campo_unico.sql` | Añade `Clientes.ibancliente` y `Facturas.factiban` (34 car.) y las rellena con los 6 bloques. Los bloques antiguos no se tocan. Hace copia de seguridad antes |
| 🔧 | `SQL/2026-10-27_Propios_mis_datos.sql` | Propios: amplía campos, nchar → nvarchar y añade `miiban` (34 car.). Los bloques antiguos no se tocan. Hace copia de seguridad antes |
| 🔧 | `SQL/2026-10-27_Propios_logo_en_tabla.sql` | Añade `Propios.milogoimagen` (imagen del logo dentro de la tabla). No toca nada más. Hace copia de seguridad antes |
| 🔧 | `SQL/2026-10-27_Retenciones_IRPF.sql` | Tabla nueva Retenciones (con General 15 % y Inicio de actividad 7 %), `Clientes.retencioncliente` y `Facturas.factretencionporc` / `factretencion`. No toca datos. Hace copia de seguridad antes |

**Todos los scripts hay que ejecutarlos una vez en cada base de datos** (la tuya y, al instalar, la del cliente), en orden de fecha.

## Pendientes anotados (para más adelante)

- [ ] El alta crea la subcarpeta `Facturacion`, pero las facturas se guardan en `Facturacion2026`.
- [ ] Historial de bajas y reactivaciones de clientes (ahora solo se guarda la última fecha de baja).
- [ ] Revisar la remesa SEPA (CBS19) con el formato vigente del banco.
- [ ] Botones del menú sin función: Listados, Agenda, Ayuda.
- [ ] Rutas fijas `C:\ByMartin\...` repartidas por el código.
- [ ] Actualizar .NET Framework 4.5.2 y ReportViewer.
- [ ] Pantalla de acceso (Control Usuarios): usar el logo guardado en la tabla Propios en vez de buscarlo en la ruta.
- [x] IBAN propio (MisDatos) en un solo campo (27-10).
- [ ] IBAN de la factura manual (FacturaUnitaria) en un solo campo, como en clientes.
- [ ] En la facturación mensual el concepto dice "Honorários" (con tilde portuguesa); en la manual, "Honorarios".
- [ ] Cuando todo funcione con `ibancliente`/`factiban`, decidir si se dejan de usar las columnas antiguas iban1..iban6.

## Hallazgos en MisDatos (27-10-2026)

- [x] Si la tabla Propios está vacía, el formulario se cae al abrir y al grabar.
- [x] Si el logo no existe en la ruta guardada, el formulario se cae al abrir. (Ahora el logo se guarda dentro de la tabla.)
- [ ] El logo elegido aquí no se usa en las facturas (llevan una imagen fija dentro del informe). **Pendiente: que las facturas usen el logo guardado en la tabla (al revisar los informes).**
- [x] Identificador bancario y BIC limitados a 4 caracteres en pantalla (el identificador SEPA tiene 7 + NIF y el BIC 8 u 11).
- [x] IBAN propio en 6 cuadros de 4.
- [x] Campos nchar: se guardan rellenos de espacios y pasan así a la remesa SEPA (nombre de hasta 100 car., SEPA admite 70).
- [x] El NIF con puntos o guiones rompe el identificador SEPA (se une al identificador bancario).
- [x] Email en mayúsculas; no avisa de errores al grabar; tabulación: identificador y BIC van después de Grabar/Salir.

## Hallazgos en Impuestos (27-10-2026)

- [x] Añadir: si algo falla (tabla vacía, % mal escrito, concepto largo) no graba y no avisa.
- [x] "5.2" con punto se guarda como 52 % (en español el punto es separador de miles).
- [x] Modificar: con un dato mal escrito el programa se cae; tras grabar el panel no se cierra y los botones quedan desactivados.
- [x] Modificar o Eliminar sin ninguna fila en la lista: el programa se cae.
- [x] Eliminar: borra sin pedir confirmación.
- [x] No limita el concepto a 20 caracteres ni el % a 99,99 (lo que admite la tabla).
- [ ] El % de recargo de equivalencia se guarda pero no se aplica en ninguna factura (tampoco la casilla R.E. del cliente).
- [ ] No hay retención de IRPF en las facturas (existe la cuenta de retenciones en Rutas, pero no se calcula).
  - [x] Fase 1 (27-10): tabla Retenciones, lista en Impuestos, casilla "Retención IRPF" en la ficha del cliente y columnas en Facturas.
  - [ ] Fase 2 (al revisar Facturación): calcular la retención en la facturación mensual y manual (total = base + IVA − retención), mostrarla en el PDF de la factura, cobrar el total líquido en la remesa y añadir la línea de retenciones en Contaplus (cuenta de Rutas). **Hasta entonces la casilla del cliente no tiene efecto.**

## Hallazgos en Backup (28-10-2026)

- [x] El servidor SQL está escrito a mano (`DESKTOP-C91G7H5\SQLEXPRESS`): en otro PC la copia falla.
- [x] Mete en el ZIP toda la carpeta C:\ByMartin, incluidas las copias anteriores (Backup) y los .bak de Historico: cada copia contiene todas las anteriores y crece sin parar. (Ahora se excluye Backup; Historico se sigue copiando a propósito.)
- [x] La carpeta tmp se añade dos veces.
- [x] Si no existen C:\ByMartin\Backup o C:\ByMartin\tmp, falla.
- [x] La copia se guarda en el mismo disco: si el disco se estropea se pierde todo.
- [x] La barra de progreso no avanza; se puede pulsar el botón dos veces o cerrar durante la copia.
- [x] Sin soporte ZIP64: si el ZIP pasa de 4 GB falla.
- [x] El nombre del fichero no ordena por fecha (ddMMyyyy).
- [x] No borra copias antiguas ni permite restaurar.

## Cambio de año sin borrar facturas (acordado 28-10-2026)

Se hará al revisar Facturación, Remesas, Contaplus y ReiniciaBases (junto con la fase 2 de retenciones):

- [ ] Columna `factejercicio` (año) en Facturas y en remesas; las existentes se rellenan con el año de su fecha.
- [ ] Numeración por año: siguiente = último número de ese año + 1 (cada enero empieza en 1 sin borrar nada).
- [ ] Selector de año en facturas, remesas, Contaplus y listados (por defecto el año actual).
- [ ] ReiniciaBases ya no borra: solo hace la copia anual a Historico la primera vez que se entra en el año nuevo.
- [ ] Opcional: recuperar los años antiguos desde los .bak de Historico.
- [ ] Arreglar: el menú lee `C:\ByMartin\System\Systemyear.txt` y ReiniciaBases usa `C:\ByMartin\Tmp\Systemyear.txt`.
- [ ] Arreglar: la numeración busca la "última factura" ordenando la fecha como texto (dd/MM/yyyy).
- [ ] Motivo: VeriFactu (obligatorio en 2027, anunciado aplazamiento a 2028) no permite borrar facturas; Hacienda puede pedir las de 4 años.
