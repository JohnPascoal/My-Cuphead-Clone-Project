# Cuphead Unity Study Project ☕️

[🇺🇸 English](../README.md) | [🇪🇸 Español](./README.es.md) | 🏴󠁥󠁳󠁧󠁡󠁿 Galego | [🇧🇷 Português (Brasil)](./README.pt-BR.md) | [🇵🇹 Português (Portugal)](./README.pt-PT.md)

Este repositorio contém un proxecto de estudo desenvolvido na **Unity Engine**, co o obxectivo de recrear e analizar as mecánicas de xogo, os sistemas de colisión e os estados da IA do xogo orixinal *Cuphead*.

---

## ⚠️ Isención de Responsabilidade / Aviso Legal (Importante)

Este proxecto é **exclusivamente para fins educativos, non comerciais e de cartafol**.

* **Propriedade Intelectual:** Todos os direitos de marca rexistrada, nome, personaxens, arte visual e banda sonora pertencen a **Studio MDHR**. Este proxecto non é oficial e non ten ningunha afiliación co desenvolvedor.
* **Propósito:** Este código foi escrito como um exercício técnico de programación e deseño de xogos. Non hai intención de infrinxir ningún dereito autor.
* **Distribución:** Este repositorio non ofrece o xogo completo e non debe usarse con fins lucrativos nin para a piratería.
* **Licenza:** A licenza MIT aplícase estritamente aos ficheiros .cs. Os ficheiros de imaxe e son contidos no cartafol /Assets/Sprites son propriedade do Studio MDHR e inclúense aquí unicamente con fins de demonstración técnica.

---

## 🎯 Obxectivos de Estudo

O foco principal desta implementación foi o desafío técnico de replicar a fluidez do xogo orixinal, contrándose en:
* **Máquinas de Estado (FSM):** Xestión dos estados do xogador (Ocioso, Correr, Saltar, Avanzarse, Parar).
* **Xefe IA:** Implementación de patróns de ataque cíclicos e transicións de fase.
* **Animación Fotograma a Fotograma:** Sincronización de animacións 2D complexas con lóxica de colisión (Hitboxes).
* **Efecto de Paralaxe:** Recreando a profundidade visual clásica dos debuxos animados dos anos 30.

## 🚀 Comezando

Siga estas instrucións para obter unha copia do proxecto em funcionamento na súa máquina local para fins de desenvolvimento e probas.

### Requisitos Previos

Antes de clonar o proxecto, asegúrate de ter instaldo o seguinte:

* **Unity Hub:** [Descarga aquí](https://unity.com/download)
* **Unity Engine:** Versión **6**
* **Git LFS:** Moi recomendable para manexar grandes recursos 2D e ficheiros de son.

### Instalación e Configuración

1. **Clonar o repositorio**
   Abra o teu terminal e execute o seguinte comando:
   ```bash
   git clone https://github.com/JohnPascoal/My-Cuphead-Clone-Project.git
   ```

2. **Engadir o proxecto a Unity Hub**

   * Abre Unity Hub.

   * Fai clic no botón Engadir (ou Abrir > Engadir proxecto desde o disco).

   * Navegue ata o cartafol clonaches o repositorio e selecciónao.

3. **Abrir e Importar**

   * Fai clic no nome do proxecto dentro de Unity Hub para lanzalo.

   * Nota: O primeiro inicio pode levar varios minutos. Unity reconstruirá automaticamente o cartafol da Biblioteca (Library) e reimportará todos os recursos (Sprites, Audio e Scripts) para coincidan co entorno local.

4. **Seleccione a Escena Inicial**

   * Unha vez aberto o editor, vai a Recursos (Assets) > Escenas (Scenes).