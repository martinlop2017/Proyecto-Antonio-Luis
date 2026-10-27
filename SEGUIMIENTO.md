# Seguimiento de la renovación — Proyecto Antonio Luis

Lista de todos los formularios del programa. Cuando un formulario está
reparado **y probado**, se tacha (~~así~~) y se marca con ✅.

Estados:
- ⬜ Pendiente de revisar
- 🔧 Modificado, **pendiente de probar** en Visual Studio
- ✅ Reparado y probado
- 🗑️ No se usa (candidato a borrar)

Última actualización: 27-10-2026 (IBAN en un solo campo)

---

## 1. Entrada al programa

| Estado | Formulario | Qué hace | Notas |
|:-:|---|---|---|
| ⬜ | Control Usuarios (`Form1`) | Pantalla de login | Cambiado el marco el 26-10 (commit de Martín) |
| ⬜ | preguntaseguridad | Pregunta de seguridad al olvidar la contraseña | |
| ⬜ | Nuevacontraseña | Cambiar la contraseña | |
| ⬜ | MenuPrincipal | Menú principal | Los botones Listados, Agenda y Ayuda no hacen nada todavía |

## 2. Clientes

| Estado | Formulario | Qué hace | Notas |
|:-:|---|---|---|
| 🔧 | GestionClientes | Lista de clientes: alta, modificar, eliminar | Recodificado 26-10. Clientes de baja en gris. Eliminar con avisos |
| 🔧 | Cliente | Ficha del cliente (alta y modificación) | Recodificado 26-10. Campos ampliados, validaciones, baja/reactivación. 27-10: IBAN en un solo campo (hasta 34) |
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
| ⬜ | Impuestos | Modelos de impuestos / IVA | |

## 5. Sistema

| Estado | Formulario | Qué hace | Notas |
|:-:|---|---|---|
| ⬜ | MisDatos (Propios) | Datos de la empresa emisora | El IBAN propio sigue en 6 cuadros de 4 |
| ⬜ | Rutas | Rutas y cuentas contables | |
| ⬜ | GestionUsuarios | Lista de usuarios | |
| ⬜ | Usuario | Ficha de usuario | |
| ⬜ | Backup | Copia de seguridad | Rutas fijas en `C:\ByMartin` |
| ⬜ | ReiniciaBases | Cierre de año / reinicio de numeración | |

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

**Todos los scripts hay que ejecutarlos una vez en cada base de datos** (la tuya y, al instalar, la del cliente), en orden de fecha.

## Pendientes anotados (para más adelante)

- [ ] El alta crea la subcarpeta `Facturacion`, pero las facturas se guardan en `Facturacion2026`.
- [ ] Historial de bajas y reactivaciones de clientes (ahora solo se guarda la última fecha de baja).
- [ ] Revisar la remesa SEPA (CBS19) con el formato vigente del banco.
- [ ] Botones del menú sin función: Listados, Agenda, Ayuda.
- [ ] Rutas fijas `C:\ByMartin\...` repartidas por el código.
- [ ] Actualizar .NET Framework 4.5.2 y ReportViewer.
- [ ] IBAN propio (MisDatos) y de la factura manual (FacturaUnitaria) en un solo campo, como en clientes.
- [ ] En la facturación mensual el concepto dice "Honorários" (con tilde portuguesa); en la manual, "Honorarios".
- [ ] Cuando todo funcione con `ibancliente`/`factiban`, decidir si se dejan de usar las columnas antiguas iban1..iban6.
