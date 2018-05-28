#  <img src="https://www.gfxmag.com/wp-content/uploads/2016/07/unity-icon-vector-logo.png" width="35"> Brick Breaker - The Game


Jogo desenvolvido em Unity 3D para a aula de Multimídia II da UFSC - Universidade Federal de Santa Catarina. 

No jogo, você controla um _paddle_ que seria como uma pá que se move na horizontal, que arremessa uma esfera contra os tijolos para quebrar os mesmos. Essa esfera ao colidir vai para a direção oposta, e você tem que mover o _paddle_ para pegar a esfera antes dela cair, para quebrar mais tijolos. O objetivo do jogo é quebrar todos os blocos para passar de fase. 

Nesse jogo foi implementado algoritmos de colisão contra o _paddle_, para a esfera se mover conforme a posição que ela toca com o mesmo. Quando a esfera passa direto é decrementado uma vida, e caso zere ele mostra mensagem de _Game Over_. Ao passar de nível temos blocos mais resistentes que quebram com dois _hits_. É feito um cálculo de pontuação também para cada bloco quebrado. Atualmente foi desenvolvido somente duas fases do jogo.
