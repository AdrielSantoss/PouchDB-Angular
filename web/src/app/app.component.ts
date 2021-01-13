import { Component } from '@angular/core';
import PouchDB from 'node_modules/pouchdb';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent {
  pouchdb: any;
  title = 'web';
  
}
