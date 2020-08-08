import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Game } from '../models/game';
import { Piece } from '../models/pieces';
import { PotentialMove, PMove } from '../models/pMove';


@Injectable({
  providedIn: 'root'
})
export class MoveService {
  baseUrl = environment.apiUrl + 'Move';
  constructor(private http: HttpClient) { }

  PossibleMove(id: number): Observable<PotentialMove[]>{
    const piec = new Piece();
    piec.id = id;
    return this.http.post<PotentialMove[]>(this.baseUrl + '/PossibleMoves', piec);
  }

  MovePiece(move: PMove): Observable<Game>{

    return this.http.post<Game>(this.baseUrl + '/MovePiece', move);
  }

  tryget(){
    return this.http.get(this.baseUrl + '/test');
  }


}
