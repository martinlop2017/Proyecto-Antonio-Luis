# Seguimiento de la renovación — Proyecto Antonio Luis

Lista de todos los formularios del programa. Cuando un formulario está
reparado **y probado**, se tacha (~~así~~) y se marca con ✅.

Estados:
- ⬜ Pendiente de revisar
- 🔧 Modificado, **pendiente de probar** en Visual Studio
- ✅ Reparado y probado
- 🗑️ No se usa (candidato a borrar)

Última actualización: 29-10-2026 (rediseño de facturación: paso 2 hecho, pendiente de probar)

> **PARA PROBAR EL PASO 2 (29-10):**
> 1. Ejecutar en Management Studio `SQL/2026-10-29_Lineas_IVA.sql` y pasar a Claude lo que salga.
> 2. En Visual Studio: "Recargar todo", **Recompilar solución**.
> 3. Probar Gestión de facturas y Factura directa (ver la lista de pruebas en "Rediseño de la facturación").

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
| 🔧 | Facturacion | Facturación mensual | 26-10: ruta de los PDF. 27-10: IBAN completo; arreglado "añadir cliente a mano" (leía columnas desplazadas). 29-10: las facturas nuevas se graban con serie M, año y fecha real, y se numeran dentro de la serie M del año (antes comparaba fechas como texto). Revisar entero en el paso 3 |
| 🔧 | GestionFacturas | Lista de facturas | 29-10: rehecho. Filtros por año y serie, búsqueda por nombre/NIF/número, columnas claras, resumen de totales, doble clic = ver, imprimir varias seleccionadas (PDF nuevo) |
| 🔧 | FacturaUnitaria | Factura directa | 29-10: rehecha. Serie D numerada por año, líneas sin límite con IVA por línea y suplidos, recargo de equivalencia, cliente ocasional, IBAN en un campo, PDF nuevo. También sirve para ver una factura emitida |
| 🗑️ | ImprimirFacturas | Imprimir un rango de facturas | 29-10: ya no se abre (se imprime desde Gestión de facturas). Corregido: marcaba como contabilizadas en vez de impresas |
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
| ✅ | `SQL/2026-10-28_Facturacion_series_lineas.sql` | Tablas Series (M mensual, D directa, R rectificativa) y FacturaLineas; en Facturas: serie, ejercicio, fecha real, origen, base imponible, enlace a remesa, estado; en remesas: año, fecha de cargo, envío y fichero. Rellena todo desde los datos existentes y copia las líneas de las facturas antiguas. No toca nada existente |
| 🔧 | `SQL/2026-10-29_Lineas_IVA.sql` | `FacturaLineas.tipoiva` / `tiporecargo` (IVA de cada línea) y `Facturas.factimporterecargo`. Copia el IVA de cada factura a sus líneas. No toca nada existente. Hace copia de seguridad antes |

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
- [x] IBAN de la factura manual (FacturaUnitaria) en un solo campo, como en clientes (29-10).
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

## Rediseño de la facturación (acordado 28-10-2026)

Decisiones: tabla de líneas (uso general), series distintas (M mensual, D directa, R rectificativa), contabilidad a Contaplus y **a3ECO**, SEPA como está (el banco lo acepta).

- [x] Paso 1: script `2026-10-28_Facturacion_series_lineas.sql` + modelo (Series, FacturaLineas, columnas nuevas).
- [x] Paso 2 (29-10, pendiente de probar): FacturaUnitaria y GestionFacturas + informe nuevo `ReportFactura.rdlc` + `Clases/FacturasUtil.cs` (numeración, cálculo, grabar, PDF).
  - IVA por línea (21, 10, 4, 0… de la tabla Iva) o "Suplido" (provisión de fondos, sin IVA).
  - Cliente ocasional: se mantiene (código 9999999999).
  - Las facturas directas se cobran **siempre en efectivo**: no se pasan al banco (sin domiciliación ni IBAN), pero sí a contabilidad. En el PDF pone "Pago en efectivo" (29-10, a petición de Antonio).
  - Número `D-2026/0001`: se asigna al grabar; cada serie empieza en 1 cada año. La fecha no puede ser anterior a la última factura de la serie.
  - Mientras no se adapten remesas y Contaplus (pasos 4 y 5), la factura nueva rellena también las columnas antiguas: base1 = base imponible, base2 = suplidos, IVA = IVA + recargo, total = lo que paga el cliente.
  - El PDF se guarda en `C:\ByMartin\Clientes\<cliente>\Facturacion<año>\Factura D-2026-0001.pdf` y la factura queda como impresa.
  - Las facturas antiguas sin líneas se imprimen montando las líneas desde sus importes.
  - Pruebas: factura a cliente de alta; a cliente ocasional domiciliado (IBAN mal → avisa); con dos tipos de IVA y un suplido; cliente con recargo; fecha anterior a la última (debe impedirlo); ver una factura antigua (mensual) y reimprimirla; imprimir varias a la vez; filtros de año y serie.
- [ ] Paso 3: Facturación mensual (serie M, líneas, ejercicio, remesa por año) + fase 2 de retenciones.
- [ ] Paso 4: Remesas / SEPA (solo la remesa elegida, total de control correcto, facturas directas domiciliadas).
- [ ] Paso 5: Contabilidad: asiento común y exportación a Contaplus y a3ECO (conseguir especificación del fichero de importación de a3ECO).
- [ ] Paso 6: Resto de informes (facturación mensual y remesas). El informe de factura con N líneas y logo ya está hecho (paso 2).

Errores encontrados al revisar (se arreglan en esos pasos):
- [x] Factura manual: guarda solo la última línea, sin IVA ni total (arreglado 29-10).
- [x] Facturas directas domiciliadas: nunca entran en una remesa (ya no aplica: las directas se cobran en efectivo, 29-10).
- [ ] CBS19 marca como domiciliadas TODAS las facturas y remesas pendientes, no solo la elegida.
- [ ] CBS19: el total de control incluye facturas no domiciliadas (el banco lo rechazaría).
- [ ] Contaplus: misma fecha para todas, todo en el asiento 1, cobro por banco también de las no domiciliadas, fichero siempre `miarchivo.txt`.
- [x] ImprimirFacturas marca las facturas como **contabilizadas** al imprimir (arreglado 29-10: ahora impresas).
- [ ] Retención IRPF en las facturas: la factura directa todavía no la aplica (fase 2, con la facturación mensual y la contabilidad).
- [ ] Cambiar la disposición del PDF de la factura (`ReportFactura.rdlc`): Antonio quiere otra distribución. No urge.
- [ ] Facturas rectificativas (serie R): pendiente, para anular o corregir una factura emitida.
