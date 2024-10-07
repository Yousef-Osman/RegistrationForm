import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { User } from '../../models/User';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { City } from '../../models/City';
import { AddressService } from '../../services/address.service';
import { Governate } from '../../models/Governate';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrl: './form.component.scss'
})
export class FormComponent implements OnInit {
  userForm: FormGroup;

  governates: Governate[] = [];
  cities: City[][] = [];
  isCityDisabled = true;

  constructor(private fb: FormBuilder,
    private router: Router,
    private userService: UserService,
    private addressService: AddressService) {
    this.userForm = this.fb.group({
      firstName: ['', Validators.required],
      middleName: [''],
      lastName: ['', Validators.required],
      birthDate: ['', Validators.required],
      mobileNumber: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
      email: ['', [Validators.required, Validators.email]],
      addresses: this.fb.array([]),
    });
  }

  ngOnInit(): void {
    this.addAddress();
    this.getGovernates();
  }

  getGovernates() {
    this.addressService.getGovernates().subscribe((governates: Governate[]) => {
      this.governates = governates;
    }, error => {
      alert(error.statusText);
    });
  }

  get addresses(): FormArray {
    return this.userForm.get('addresses') as FormArray;
  }

  addAddress() {
    const addressGroup = this.fb.group({
      governateId: [null, Validators.required],
      cityId: [{ value: null, disabled: true }, Validators.required],
      street: ['', Validators.required],
      buildingNumber: ['', Validators.required],
      flatNumber: ['', [Validators.required, Validators.pattern('^[0-9]*$')]],
    });

    // Add an empty array to citiesList for the new address
    this.cities.push([]);

    //get the index of the new address
    const index = this.addresses.length;
    addressGroup.get('governateId')?.valueChanges.subscribe(governateId => {
      if (governateId) {
        addressGroup.get('cityId')?.disable();

        //subscripe to governate change
        this.addressService.getCitiesByGovernate(governateId).subscribe(cities => {
          //add new city list array ti the cities array of arrays
          this.cities[index] = cities;
          addressGroup.get('cityId')?.enable();
        });
      }
    });

    this.addresses.push(addressGroup);
  }

  removeAddress(index: number) {
    if (this.addresses.length > 1)
      this.addresses.removeAt(index);
  }

  onSubmit(): void {
    if (this.userForm.valid) {
      const user: User = this.userForm.value;
      this.userService.createUser(user).subscribe(
        (response) => {
          this.router.navigate(['/success']);
        },
        (error) => {
          alert('Error: Registrtion Failed');
        }
      );
    } else {
      alert('Form is invalid');
    }
  }
}
