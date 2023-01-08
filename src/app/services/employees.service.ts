import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../Models/employee.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EmployeesService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) {}

  getAllEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseApiUrl + '/api/employees');
  }

  addEmployee(addEmployeeReq: Employee): Observable<Employee> {
    addEmployeeReq.id = '00000000-0000-0000-0000-000000000000';
    return this.http.post<Employee>(
      this.baseApiUrl + '/api/employees',
      addEmployeeReq
    );
  }

  getEmployee(id: string): Observable<Employee> {
    return this.http.get<Employee>(this.baseApiUrl + '/api/employees/' + id);
  }

  updateEmployee(
    id: string,
    updateEmployeeRequest: Employee
  ): Observable<Employee> {
    return this.http.put<Employee>(
      this.baseApiUrl + '/api/employees/' + id,
      updateEmployeeRequest
    );
  }

  deleteEmployee(id: string): Observable<Employee> {
   return  this.http.delete<Employee>(this.baseApiUrl + '/api/employees/' + id);
  }
}
