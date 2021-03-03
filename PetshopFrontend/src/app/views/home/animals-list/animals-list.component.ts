import { Component, OnInit } from '@angular/core';
import { Animal } from 'src/app/shared/models/animal.model';
import { AnimalService } from 'src/app/shared/service/animal.service';

@Component({
  selector: 'app-animals-list',
  templateUrl: './animals-list.component.html',
  styleUrls: ['./animals-list.component.css']
})
export class AnimalsListComponent implements OnInit {

  displayedColumns: string[] = ['name','guardianName', 'guardianAddress', 'guardianPhone'];
  animals: Animal[] = [];

  constructor(
    public animalService: AnimalService
  ) { }

  ngOnInit(): void {
    this.getAnimals();
  }

  getAnimals() {
    this.animalService.getAnimals().subscribe(data => {
      this.animals = data;
    });
  }
}
