import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import PouchDB from 'node_modules/pouchdb';
import PouchDBFind from 'node_modules/pouchdb-find';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  pouchdb: any;
  result: any;

  
  constructor(private formBuilder: FormBuilder) {
    
    this.pouchdb = new PouchDB("http://localhost:5984/pouachform");
    PouchDB.plugin(PouchDBFind);

    this.pouchdb.createIndex({
      index: {fields: ['name']}
    })

  }

  pouchform = this.formBuilder.group(
    {
      name: '',
      email: '',
      searchName: '',
      newName: '',
      newEmail: ''
    }
  )

  ngOnInit() {
  }  


  create() {
    var pouchform = {
      _id: new Date().toISOString(),
      name: this.pouchform.value.name,
      email: this.pouchform.value.email,
    }

    this.pouchdb.put(pouchform, function (result, error){
      //console.log(result);
      
      if(!error){
        alert("Salvado com sucesso!")
      }
    })
  } 

   async read(){
     let records = await this.getForms(this.pouchform.value.searchName); 

     this.result = records.docs; //
  }

  getForms(searchName){
      return this.pouchdb.find({
        selector: {
          name: searchName
        } 
      })
  }

  update(e){
    console.log(e.toElement.name)
    console.log(this.result[0])

    let pouchForm = {
      _id: this.result[0]._id,
      _rev: this.result[0]._rev,
      name: this.pouchform.value.newName,
      email: this.pouchform.value.newEmail
    }

    this.pouchdb.put(pouchForm, function (result, error) {

      console.log(result);

      if (!error) {

        alert("Atualizado com sucesso!")
      }
    });
  }

  delete(){
    this.pouchdb.remove(this.result[0]);
  }

}
