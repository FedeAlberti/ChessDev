import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-board-square',
  templateUrl: './board-square.component.html',
  styleUrls: ['./board-square.component.css']
})
export class BoardSquareComponent implements OnInit {
  @Input()x: number;
  @Input()y: number;

   yy: number;

  constructor() {
    this.yy = 0;
   }

  ngOnInit(): void {
  }

  getCssClass() {
    let cssString = '';
    switch (this.y) {
      case 1:
        cssString = 'white-Pawn';
        break;
      case 6:
        cssString = 'black-Pawn';
      default:
        break;
    }

    return cssString;
  }

  test(){
    console.log("cos");
    debugger;
    if(this.yy === 0)
    {
    const element = document.getElementById('0-0');
    element.style.backgroundColor = 'green';
    this.yy = 1;
    }else{
      this.yy = 0;
      const element = document.getElementById('0-0');
      element.style.backgroundColor = '';
    }
  }
}
