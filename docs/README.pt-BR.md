# Cuphead Unity Study Project ☕️

[🇺🇸 English](../README.md) | [🇪🇸 Español](./README.es.md) | [🏴󠁥󠁳󠁧󠁡󠁿 Galego](./README.gl.md) | 🇧🇷 Português (Brasil) | [🇵🇹 Português (Portugal)](./README.pt-PT.md)

Este repositório contém um projeto de estudo desenvolvido na **Unity Engine**, com o objetivo de recriar e analisar a mecânica de jogo, os sistemas de colisão e os estados da IA do jogo original *Cuphead*.

---

## ⚠️ Isenção de Responsabilidade / Aviso Legal (Importante)

Este projeto destina-se **exclusivamente a fins educativos, não comerciais e para fins de portfólio**.

* **Propriedade Intelectual:** Todos os direitos de marca registrada, nome, personagens, arte visual e trilha sonora pertencem ao **Studio MDHR**. Este projeto não é oficial e não possui qualquer vínculo com o desenvolvedor.
* **Propósito:** Este código foi escrito como um exercício técnico de programação e design de jogos. Não há intenção de infringir quaisquer direitos autorais.
* **Distribuição:** O repositório não fornece o jogo completo e não deve ser usado para fins lucrativos ou pirataria.
* **Licença:** A licença MIT aplica-se estritamente aos arquivos .cs. Os arquivos de imagem e som contidos na pasta /Assets/Sprites são propriedade do Studio MDHR e estão incluídos aqui exclusivamente para fins de demonstração técnica.

---

## 🎯 Objetivos de Estudo

O foco principal desta implementação foi o desafio técnico de replicar a fluidez do jogo original, concentrando-se em:
* **Máquinas de Estado (FSM):** Gerenciar os estados do jogador (Ocioso, Correndo, Pulando, Investida, Aparar).
* **IA do Chefe:** Implementação de padrões de ataque cíclicos e transições de fase.
* **Animação Quadro a Quadro:** Sincronização de animações 2D complexas com lógica de colisão (Hitboxes).
* **Efeito de Paralaxe:** Recriando a profundidade visual clássica dos desenhos animados da década de 1930.

## 🚀 Primeiros Passos

Siga estas instruções para obter uma cópia do projeto em funcionamento na sua máquina local para fins de desenvolvimento e teste.

### Pré-requisitos

Antes de clonar o projeto, certifique-se de ter os seguintes itens instalados:

* **Unity Hub:** [Baixe aqui](https://unity.com/download)
* **Unity Engine:** Versão **6**
* **Git LFS:** Altamente recomendado para lidar com grandes arquivos 2D e de áudio.

### Instalação e Configuração

1. **Clonar o repositório**
   Abra o terminal e execute o seguinte comando:
   ```bash
   git clone https://github.com/JohnPascoal/My-Cuphead-Clone-Project.git
   ```

2. **Adicione o projeto ao Unity Hub**

   * Abra Unity Hub.

   * Clique no botão Adicionar (ou Abrir > Adicionar projeto do disco).

   * Navegue até a pasta onde você clonou o repositório e selecione-o.

3. **Abrir e Importar**

   * Clique no nome do projeto no Unity Hub para iniciá-lo.

   * Nota: A primeira execução pode levar alguns minutos. O Unity reconstruirá automaticamente a pasta Biblioteca (Library) e reimportará todos os recursos (Sprites, Áudio e Scripts) para corresponder ao seu ambiente local.

4. **Selecione a Cena Inicial**

   * Com o editor aberto, acesse Recursos (Assets) > Cenas (Scenes).