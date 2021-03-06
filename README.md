# Aplicación Móvil Agenda Mujer

La Agenda Mujer tiene como pilares fundamentales la defensa del derecho humano de las mujeres a una vida libre de violencia, la igualdad ante la ley y la no discriminación de las personas, priorizando la defensa de aquellas en situación de vulnerabilidad:

* Lucha contra la violencia hacia las mujeres, niñas y niños.
* Empoderamiento de las mujeres para su participación en la vida política, económica y social, libre de discriminación y violencia.
* Protección de las personas en situación de vulnerabilidad.

## Dependencias

* NETStandard.Library (2.0.3)
* Newtonsoft.Json (13.0.1)
* Xamarin.CommunityToolkit (1.2.0)
* Xamarin.CommunityToolkit.Markup (1.2.0)
* Xamarin.Essentials (1.6.1)
* Xamarin.Forms (5.0.0.2012)
* Xamarin.Forms.Bootstrap.Icons (1.5.0)
* Xamarin.Forms.Maps (5.0.0.2012)

## Configuración

### Android

Requiere habilitada la **Maps SDK for Android** API en Google Cloud Platform y un recurso de tipo cadena de texto con el nombre `google_maps_api_key` que mantenga el valor de la llave de acceso correspondiente:

```xml
<?xml version="1.0" encoding="utf-8"?>
<resources>
    <string name="google_maps_api_key">TU_GOOGLE_MAPS_API_KEY</string>
</resources>
```

## Ejecutables

* [Agenda Mujer - Apps on Google Play](https://play.google.com/store/apps/details?id=com.epicalsoft.agendamujer)


## Licencia

Este proyecto tiene la [Licencia MIT][1].

[1]: https://opensource.org/licenses/mit-license.html "The MIT License | Open Source Initiative"