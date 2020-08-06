import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Game } from 'src/app/models/game';
import { Piece } from 'src/app/models/pieces';
import { MoveService } from 'src/app/services/move.service';

@Component({
  selector: 'app-board-square',
  templateUrl: './board-square.component.html',
  styleUrls: ['./board-square.component.css']
})
export class BoardSquareComponent implements OnInit {
  @Input() x: number;
  @Input() y: number;
  @Output() clicksquare = new EventEmitter();

  @Input()
  get game(): Game { return this._game; }
  set game(game: Game) {
    this.getPiece(game);
  }

  // tslint:disable-next-line: variable-name
  private _game: Game;
  // tslint:disable-next-line: variable-name
  private _piece: Piece;
  private potmov: PotentialMove = null;

  constructor(private moveservice: MoveService) {

  }

  ngOnInit(): void {
  }

  getCssClass() {
    let cssString = '';
    if (this._piece) {
      cssString = this._piece.color + '-' + this._piece.pieceType;
    }else{
      cssString = '';
    }
    return cssString;
  }

  getPiece(game: Game) {
    if (game) {
      this._piece = game.pieces.find(piece => piece.x === this.x && piece.y === this.y);
    }
  }

  test() {
    debugger;
    if (this._piece) {
      this.moveservice.PossibleMove(this._piece.id).subscribe(x => {
        this.limpiarCuadrito();
        debugger;
        x.forEach(element => {
          this.pintarCuadrito(element);
        });
        this.potmov = new PotentialMove(this.x, this.y, this._piece , x);
        this.clicksquare.emit(this.potmov);
      }
      );
    } else {
      this.potmov = new PotentialMove(this.x, this.y);
      this.clicksquare.emit(this.potmov);
      this.limpiarCuadrito();
    }
  }

  pintarCuadrito(potLoc: PotentialMove) {

    if (potLoc) {
      const coso = potLoc.x + '-' + potLoc.y;
      const element = document.getElementById(coso);
      element.style.backgroundColor = 'green';

    }
  }

  limpiarCuadrito() {
    for (let index = 0; index <= 7; index++) {
      for (let index2 = 0; index2 <= 7; index2++) {
        const coso = index + '-' + index2;
        const element = document.getElementById(coso);
        element.style.backgroundColor = '';
      }
    }
  }
}

export class PotentialMove {
  piece: Piece;
  moves: PMove[];
  x: number;
  y: number;

  constructor(x?: number, y?: number, piece?: Piece, pmove?: PMove[] ) {
    this.x = x;
    this.y = y;
    this.piece = piece;
    this.moves = pmove;
  }
}

export class PMove {
  x: number;
  y: number;
  piece: Piece;

  constructor(x?: number, y?: number, piece?: Piece ) {
    this.x = x;
    this.y = y;
    this.piece = piece;
  }
}
