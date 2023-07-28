import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  // Properties
  title = 'DatingApp'; // hier ist keine Deklaration für string nötig, weil ihm eh direkt ein string zugewiesen wird
  users: any; //keine Typesafety, unbedingt Vorsicht damit

  // DI für meine User
  // Constructor
  constructor(private http: HttpClient) {}

  // Methods
  ngOnInit(): void {
    //get is observable, muss daher noch wo subscriben weil observables lazy sind und nichts automatisch tun
    this.http.get('https://localhost:5001/api/users').subscribe({
      // was soll es als nächstes tun, sobals es durch das get einen response bekommen hat?
      next: response => this.users = response,
      // was soll es bei einem error tun?
      error: error => console.log(error),
      // was soll es zum schluss unserer funktion tun?
      complete: () => console.log('Request has completed')
    })
  }
}
