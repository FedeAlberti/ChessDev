import { Game } from './game';

export class Piece {

  id: number;
  x: number;
  y: number;
  pieceType: string;
  color: string;

  // move coordinates and the enemy piece discriminator it would capture
  possibleMoves?: Map<string, string>;

  static getMapKey(x: number, y: number) {
      return x.toString() + '-' + y.toString();
  }
}
