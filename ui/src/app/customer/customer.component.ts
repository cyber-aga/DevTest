import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { take, tap } from 'rxjs/operators';
import { CustomerService } from '../services/customer.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  customerTypeOptions$: Observable<string[]>;
  customers$;

  customerForm: FormGroup = this._fb.group({
    name: ['', [Validators.required, Validators.minLength(5)]],
    type: ['', Validators.required]
  });

  constructor(private _fb: FormBuilder, private _customerService: CustomerService) { }

  ngOnInit(): void {
    this.customerTypeOptions$ = this._customerService.getCustomerTypes();
    this._loadCustomers();
  }

  createCustomer(): void {
    if (this.customerForm.invalid) {
      return;
    }
    const newCustomer = {
      name: this.customerForm.controls.name.value,
      type: this.customerForm.controls.type.value
    };

    this._customerService.postCustomer(newCustomer).pipe(take(1), tap(() => this._loadCustomers())).subscribe();
  }

  private _loadCustomers() {
    this.customers$ = this._customerService.getCustomers();
  }
}
