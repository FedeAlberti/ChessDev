import { Component } from '@angular/core';
import { Game } from 'src/app/models/game';
import { GameService } from 'src/app/services/game.service';
import { MoveService } from 'src/app/services/move.service';
import { PotentialMove, PMove } from '../board-square/board-square.component';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent {

  boardX: any[];
  boardY: any[];
  game: Game;
  potmov: PotentialMove;
  potmovNew: PotentialMove;

  isMoving = false;
  isWaitForServer = false;

  constructor(private gameservice: GameService,
              private moveservice: MoveService) {
    this.boardX = Array(0, 1, 2, 3, 4, 5, 6, 7);
    this.boardY = Array(7, 6, 5, 4, 3, 2, 1, 0);
    this.newGame();
  }

  newGame() {
    this.gameservice.newGame().subscribe(gameresp => {
      this.game = gameresp;
    });
    setTimeout(() => {
    }, 100);
  }

  pickPiece(event: PotentialMove){
    debugger;
    if ( !this.isMoving)
    {
      this.isMoving = true;
      this.potmov = event;
    }else
    {
      let eee = this.potmov.moves.find(x => x.x === event.x && x.y === event.y);
      if (eee){
        let aa = new PMove(eee.x, eee.y, this.potmov.piece);
        this.moveservice.MovePiece(aa).subscribe(x => {
          debugger;
          this.game = x;
          this.isMoving = false;
          this.potmov = null;
        })
      }
    }
  }

}
