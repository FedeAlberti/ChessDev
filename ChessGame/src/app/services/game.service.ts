import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Game } from '../models/game';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  baseUrl = environment.apiUrl + 'Game';

constructor(private http: HttpClient) { }

newGame() {
  return this.http.post<Game>(this.baseUrl + '/NewGame', null);
}

}
