# Cuphead Unity Study Project ☕️

[🇺🇸 English](../README.md) | 🇪🇸 Español | [🏴󠁥󠁳󠁧󠁡󠁿 Galego](./README.gl.md) | [🇧🇷 Português (Brasil)](./README.pt-BR.md) | [🇵🇹 Português (Portugal)](./README.pt-PT.md)

Este repositorio contiene un proyecto de estudio desarrollado en el **Unity Engine**, con el objetivo de recrear y analizar las mecánicas de juego, los sistemas de colisión y los estados de IA del juego original *Cuphead*.

---

## ⚠️ Aviso Legal (Importante)

Este proyecto es **exclusivamente para fines educativos, no comerciales y de portafolio**.

* **Propiedad Intelectual:** Todos los derechos de marca registrada, nombre, personajes, arte visual y banda sonora pertenecen a **Studio MDHR**. Este proyecto no es oficial y no tiene ninguna afiliación con el desarrollador.
* **Propósito:** Este código fue escrito como un ejercicio técnico de programación y diseño de videojuegos. No se pretende infringir ningún derecho de autor.
* **Distribución:** Este repositorio no proporciona el juego completo y no debe utilizarse con fines lucrativos ni para la piratería.
* **Licencia:** La licencia MIT se aplica estrictamente a los archivos .cs. Los archivos de imagen y sonido que se encuentran en la carpeta /Assets/Sprites son propriedad de Studio MDHR y se incluyen aquí únicamente con fines de demostración técnica.

---

## 🎯 Objetivos de Estudio

El objetivo principal de esta implementación fue el desafío técnico de replicar la fluidez del juego original, centrándose en:
* **Máquinas de Estado (FSM):** Gestionar los estados del jugador (Inactivo, Correr, Saltar, Esprintar, Parar).
* **Jefe IA:** Implementación de patrones de ataque cíclicos y transiciones de fase.
* **Animación Fotograma a Fotograma:** Sincronización de animaciones 2D complejas con lógica de colisión (Cajas de colisión).
* **Efecto de Paralaje:** Recreando la profundidad visual clásica de los dibujos animados de la década de 1930.

## 🚀 Primeros Pasos

Siga estas instrucciones para obtener una copia del proyecto y ponerla en funcionamiento en su máquina local con fines de desarrollo y prueba.

### Requisitos Previos

Antes de clonar el proyecto, asegúrese de tener instalado lo siguiente:

* **Unity Hub:** [Descargar aquí](https://unity.com/download)
* **Unity Engine:** Version **6**
* **Git LFS:** Muy recomendable para manejar archivos de audio y recursos 2D de gran tamaño.

### Instalación y Configuración

1. **Clonar el repositorio**
   Abre tu terminal y ejecuta el siguiente comando:
   ```bash
   git clone https://github.com/JohnPascoal/My-Cuphead-Clone-Project.git
   ```

2. **Agrega el proyecto a Unity Hub**

   * Abrir Unity Hub.

   * Haz clic en el botón Agregar (o Abrir > Agregar proyecto desde disco).

   * Navegue hasta la carpeta donde clonó el repositorio y selecciónelo.

3. **Abrir e Importar**

   * Haz clic en el nombre del proyecto dentro de Unity Hub para iniciarlo.

   * Nota: El primer inicio puede tardar varios minutos. Unity reconstruirá automáticamente la carpeta Biblioteca (Library) y volverá a importar todos los recursos (Sprites, Audio y Scripts) para que coincidan con tu entorno local.

4. **Seleccione la Escena Inicial**

   * Una vez abierto el editor, vaya a Activos (Assets) > Escenas (Scenes).