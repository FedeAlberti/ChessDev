import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BoardComponent } from './game/board/board.component';
import { BoardSquareComponent } from './game/board-square/board-square.component';
import { HttpClientModule } from '@angular/common/http';
import { GameService } from './services/game.service';
import { MoveService } from './services/move.service';

@NgModule({
  declarations: [
    AppComponent,
    BoardComponent,
    BoardSquareComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [
    GameService,
    MoveService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
