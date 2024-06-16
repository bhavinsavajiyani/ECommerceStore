import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.scss']
})
export class TestErrorComponent {
  baseURL = environment.apiUrl;
  validationErrors: string[] = [];

  constructor(private http: HttpClient) {}

  get404Error() {
    this.http.get(this.baseURL + 'buggy/notfound').subscribe({
      next: response => console.log(response),
      error: error => {
        console.log(error);
        this.validationErrors = error.errors;
      }
    })
  }

  get500Error() {
    this.http.get(this.baseURL + 'buggy/servererror').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  get400Error() {
    this.http.get(this.baseURL + 'buggy/badrequest').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }

  get400ValidationError() {
    this.http.get(this.baseURL + 'buggy/badrequest/fourtytwo').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    })
  }
}
