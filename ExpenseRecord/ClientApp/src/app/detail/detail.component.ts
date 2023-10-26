import { Component, OnInit } from '@angular/core';
import { HttpconnectService } from '../httpconnect.service';
import {ExpenseRecord} from '../expenseRecord';
@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit {
  showForm = false;
  // items:ExpenseRecord[] |undefined;
  itemsDisplay:ExpenseRecord[] =[];
  add_item:ExpenseRecord = {id:'2',description:'2',type:'3',amount:3 ,date:new Date(2022,1,3)};
  // add_item:ExpenseRecordCreate = {Description:'2',Type:'3',Amount:3 };

  constructor(   private httpconnect: HttpconnectService) { }


  ngOnInit(): void {
    this.getItems();

  }
  getItems(): void {
    console.log("get");
    this.httpconnect.getItems()
    .subscribe(items => {
      this.itemsDisplay = items;
      console.log("itemDisplay", this.itemsDisplay)
    });
    // this.httpconnect.getItems().subscribe(a=>{this.item=a})

  }


  toggleForm() {
    this.showForm = !this.showForm;
  }

  add=()=>{
    this.httpconnect.insertItems(this.add_item).subscribe(()=>location.reload());
  };
  delete=( id:string)=>{
    this.httpconnect.deleteItems(id).subscribe(()=>location.reload());}

}
