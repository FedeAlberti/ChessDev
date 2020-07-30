import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BoardComponent } from './game/board/board.component';
import { BoardSquareComponent } from './game/board-square/board-square.component';

@NgModule({
  declarations: [
    AppComponent,
    BoardComponent,
    BoardSquareComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
