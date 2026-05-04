# Cuphead Unity Study Project ☕️

[🇺🇸 English](../README.md) | [🇪🇸 Español](./README.es.md) | [🏴󠁥󠁳󠁧󠁡󠁿 Galego](./README.gl.md) | [🇧🇷 Português (Brasil)](./README.pt-BR.md) | 🇵🇹 Português (Portugal)

Este repositório contém um projeto de estudo desenvolvido no **Unity Engine**, com o objetivo de recriar e analisar a mecânica de jogo, os sistemas de colisão e os estados da IA do jogo original *Cuphead*.

---

## ⚠️ Isenção de Responsabilidade / Aviso Legal (Importante)

Este projeto destina-se **exclusivamente a fins educativos, não comerciais e para fins de portfólio**.

* **Propriedade Intelectual:** Todos os direitos de marca registrada, nome, personagens, arte visual e banda sonora pertencem ao **Studio MDHR**. Este projeto não é oficial e não possui qualquer vínculo com o desenvolvedor.
* **Propósito:** Este código foi escrito como um exercício técnico de programação e design de jogos. Não há intenção de infringir quaisquer direitos autorais.
* **Distribuição:** O repositório não fornece o jogo completo e não deve ser utilizado para fins lucrativos ou pirataria.
* **Licença:** A licença MIT aplica-se estritamente aos ficheiros .cs. Os ficheiros de imagem e som contidos na pasta /Assets/Sprites são propriedade do Studio MDHR e estão aqui incluídos exclusivamente para fins de demonstração técnica.

---

## 🎯 Metas de Estudo

O foco principal desta implementação foi o desafio técnico de replicar a fluidez do jogo original, focando-se em:
* **Máquinas de Estado (FSM):** Gerir os estados do jogador (Inactivo, Correndo, Saltando, Investida, Aparar).
* **IA do Boss:** Implementação de padrões de ataque cíclicos e transições de fase.
* **Animação Quadro a Quadro:** Sincronização de animações 2D complexas com lógica de colisão (Hitboxes).
* **Efeito de Paralaxe:** Recriando a profundidade visual clássica dos desenhos animados da década de 1930.

## 🚀 Começando

Siga estas instruções para obter uma cópia do projeto em funcionamento na sua máquina local para fins de desenvolvimento e teste.

### Pré-requisitos

Antes de clonar o projeto, certifique-se de ter os seguintes itens instalados:

* **Unity Hub:** [Baixe aqui](https://unity.com/download)
* **Unity Engine:** Versão **6**
* **Git LFS:** Altamente recomendado para lidar com grandes ficheiros 2D e de áudio.

### Instalação e Configuração

1. **Clonar o repositório**
   Abra o terminal e execute o seguinte comando:
   ```bash
   git clone https://github.com/JohnPascoal/My-Cuphead-Clone-Project.git
   ```

2. **Adicione o projeto ao Unity Hub**

   * Abra Unity Hub.

   * Clique no botão Adicionar (ou Abrir > Adicionar projeto do disco).

   * Navegue até à pasta onde você clonou o repositório e selecione-o.

3. **Abrir e Importar**

   * Clique no nome do projeto no Unity Hub para o iniciar.

   * Nota: A primeira execução pode demorar alguns minutos. O Unity irá reconstruir automaticamente a pasta Biblioteca (Library) e reimportar todos os recursos (Sprites, Áudio e Scripts) para corresponder ao seu ambiente local.

4. **Selecione a Cena Inicial**

   * Com o editor aberto, aceda a Recursos (Assets) > Cenas (Scenes).