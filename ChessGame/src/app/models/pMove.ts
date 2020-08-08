import { Piece } from './pieces';

export class PotentialMove {
  piece: Piece;
  moves: PMove[];
  x: number;
  y: number;

  constructor(x?: number, y?: number, piece?: Piece, pmove?: PMove[]) {
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

  constructor(x?: number, y?: number, piece?: Piece) {
    this.x = x;
    this.y = y;
    this.piece = piece;
  }
}
