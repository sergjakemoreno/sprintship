import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PersonServiceProxy, PersonListDto, AddPhoneInput, PhoneType } from '@shared/service-proxies/service-proxies';
import * as _ from 'lodash';

@Component({
    templateUrl: './phonebook.component.html',
    animations: [appModuleAnimation()]
})

export class PhoneBookComponent extends AppComponentBase implements OnInit {

    persons: PersonListDto[] = [];
    filter: string;
    editingPerson: PersonListDto;
    newPhone: AddPhoneInput;

    constructor(
        injector: Injector,
        private _personService: PersonServiceProxy
    ) { 
        super(injector); 
    }
    
    ngOnInit(){
        this.getPeople();
    }

    getPeople(): void {
        this._personService.getPeople(this.filter).subscribe((result) => {
            this.persons = result.items;
        });
    }

    deletePerson(person: PersonListDto): void {
        this.message.confirm(this.l('Warning', person.name),
        this.l('Are you sure you want to delete this user?'),
        isConfirmed => {
            if (isConfirmed){
                this._personService.deletePerson(person.id).subscribe(() => {
                    this.message.info('Deleted Successfully');
                    _.remove(this.persons, person);
                });
            }
        });
    }

    editPhone(person: PersonListDto): void {
        console.log(person + ' ' + this.editingPerson);
        if (person === this.editingPerson){
            this.editingPerson = null;
        } else {
            this.editingPerson = person;

            this.newPhone = new AddPhoneInput();
            this.newPhone.type = PhoneType.Home;
            this.newPhone.personId = person.id;
        }
    }

    getPhoneTypeAsString(phoneType: PhoneType): string {
        switch(phoneType){
            case PhoneType.Mobile:
                return this.l('Mobile');
            case PhoneType.Home:
                return this.l('Home');
            case PhoneType.Business:
                return this.l('Business');
            default:
                return '?';
        }
    }

    deletePhone(phone, person): void {
        this._personService.deletePhone(phone.id).subscribe(() => {
            this.notify.success('Deleted Successfully');
            _.remove(person.phones, phone);
        });
    }

    savePhone(): void{
        if (!this.newPhone.number)
        {
            this.message.warn('Please enter new number');
            return;
        }

        this._personService.addPhone(this.newPhone).subscribe((result) => {
            this.editingPerson.phones.push(result);
            this.newPhone.number = '';
            this.notify.success('Saved Successfully');
        });
    }


}