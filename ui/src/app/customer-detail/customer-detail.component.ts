import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { CustomerModel } from '../models/customer.model';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss']
})
export class CustomerDetailComponent implements OnInit {
  customer$: Observable<CustomerModel>;
  private _customerId: number;

  constructor(route: ActivatedRoute,
    private _customerService: CustomerService) {
    this._customerId = +route.snapshot.paramMap.get('id')
  }

  ngOnInit(): void {
    this.customer$ = this._customerService.getCustomerById(this._customerId);
  }

}
