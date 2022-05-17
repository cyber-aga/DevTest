import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CustomerPostModel } from '../models/customer-post.model';
import { CustomerModel } from '../models/customer.model';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private _httpClient: HttpClient) { }

  public getCustomers(): Observable<string[]> {
    return this._httpClient.get<string[]>('http://localhost:63235/customer');
  }

  public getCustomerTypes(): Observable<string[]> {
    return this._httpClient.get<string[]>('http://localhost:63235/customer/types');
  }

  public getCustomerById(id: number): Observable<CustomerModel> {
    return this._httpClient.get<CustomerModel>(`http://localhost:63235/customer/${id}`);
  }

  public postCustomer(customerModel: CustomerPostModel) {
    return this._httpClient.post('http://localhost:63235/customer', customerModel);
  }
}
