# Cheat para el juego Preguntados o más conocido como TriviaCrack

[![Latest release](https://img.shields.io/github/release/JAX20/Cheat-TriviaCrack.svg)](https://github.com/JAX20/Cheat-TriviaCrack/releases)
[![License GPL-3.0](https://img.shields.io/badge/license-GPL--3.0-brightgreen.svg)](https://github.com/JAX20/Cheat-TriviaCrack/blob/master/LICENSE)

Una aplicación simple para encontrar automáticamente la respuesta correcta en el juego Trivia Crack en Facebook (https://apps.facebook.com/triviacrack/).

# Comunicación con el servidor
Este juego se comunica con el servidor mediante solicitudes HTTPS.

![Image](https://image.ibb.co/b4xUa9/capture_Api_Preguntados_1.png)

Las respuestas que envía el servidor son objetos JSON que contienen detalles de tus partidas activas, configuraciones del juego... en general información de todo lo que es el juego. Todo esto sin ninguna medida para proteger dicha información.

###### Una pequeña demostración 
![Image](https://image.ibb.co/haUHCp/capture_Api_Preguntados_2.png)

# FiddlerCore y MakeCert
Con FiddlerCore intercepto el tráfico entre el cliente-servidor, con él lograré que haga de intermediario entre el navegador y la aplicación sin hacer uso de la UI de Fiddler.

De forma predeterminada solo intercepta el tráfico HTTP. Como el juego integra el protocolo HTTPS en sus comunicaciones, hay que configurarlo para que descrifre el tráfico HTTPS. 

El proxy ejecutará un ataque MITM; pero antes Fiddler debe generar un certificado raíz y usar ese certificado raíz para generar múltiples certificados de entidad final, uno para cada sitio HTTPS.

Aquí entra en juego la herramienta MakeCert que es la encargada de crear el certificado raíz.

FiddlerCore ya incluye las funciones necesarias para instalar el certificado utilizando MakeCert.

	if (!CertMaker.rootCertExists())
	{
		if (!CertMaker.createRootCert())
			throw new Exception("Unable to create certificate for FiddlerCore.");

		if (!CertMaker.trustRootCert())
			throw new Exception("Unable to create certificate for FiddlerCore.");
	}
Es importante aceptar el cuadro de diálogo que aparece en pantalla para la correcta instalación del certificado.

# Plataformas
Probado en Windows 7 x86/x64 y Windows 10 x86/x64.
Se encuentra configurado como plataforma de destino x86 por lo que no hay ningún problema en usarlo en x64.

# Requisitos
> .NET Framework 4.5.2 o posterior.

# Características disponibles

Función | Disponible
------------ | -------------
Partida en modo de juego clásico | Sí
Partida en modo de juego duelo | No
Desafiar a tu oponente cuando toca Corona | No
Jugar por un personaje cuando toca Corona | Sí
Respuestas de todas las categorías cuando toca Corona | ~~No~~ Sí
Respuesta de una sola categoría cuando toca Corona | Sí
Respuesta al hacer un segundo intento tras fallar | ~~No~~ Sí

# Posibles problemas y su solución
1. Si después de haber instalado el certificado usted recibe el mensaje "La conexión no es privada", cierre y abra nuevamente el navegador. Esto debería ser más que suficiente.

2. Si después de cerrar Cheat Preguntados usted recibe el mensaje "Sin conexión a Internet", desactive la configuración del proxy manualmente en su equipo. Esto no debería de ocurrir. [Desactivar proxy](https://www.google.es/search?q=disable+proxy+settings)

# Imagen del funcionamiento
![Image](https://image.ibb.co/eMtnPe/Trivia_Crack_Crown.png)
![Image](https://image.ibb.co/m3tAcz/Trivia_Crack_Crown_And_Second_Chance_Question.png)

# Librerías externas utilizadas
> [FiddlerCore](https://www.telerik.com/fiddler/fiddlercore)

> [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)

> [Colorful.Console](https://github.com/tomakita/Colorful.Console)

## Nota
Este proyecto ha sido realizado y publicado con fines educativos para el aprendizaje y así demostrar los riesgos que existen al no utilizar las medidas correctas de seguridad. En ningún momento me hago responsable de su mal uso.

**Cualquier problema házmelo saber!.**
