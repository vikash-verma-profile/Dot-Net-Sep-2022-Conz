import { Component } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'sample-project';
  imageURL="././assets/image.jpg";

  show(){
    debugger;
    console.log('HI');
    alert('HI');
  }
}
