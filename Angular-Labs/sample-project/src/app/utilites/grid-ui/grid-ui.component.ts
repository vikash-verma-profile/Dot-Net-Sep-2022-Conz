import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-grid-ui',
  templateUrl: './grid-ui.component.html'
})
export class GridUiComponent implements OnInit {

  constructor() { }

  //getting column names
  gridColumns: Array<any> = new Array<any>();

  //getting column data
  gridData: Array<any> = new Array<any>();

  ngOnInit(): void {
  }

  @Input("grid-columns")
  set SetGridColumns(_gridColumn:Array<any>){
    this.gridColumns=_gridColumn;
  }

  @Input("grid-data")
  set SetGridData(_gridData:Array<any>){
    this.gridData=_gridData;
  }
}

