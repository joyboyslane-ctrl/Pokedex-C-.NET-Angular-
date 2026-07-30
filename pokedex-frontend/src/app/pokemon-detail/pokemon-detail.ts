import { Component, OnInit, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PokemonService } from '../services/pokemon.service';
import { Pokemon } from '../models/pokemon.model';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-pokemon-detail',
  imports: [RouterLink],
  templateUrl: './pokemon-detail.html',
  styleUrl: './pokemon-detail.css',
})
export class PokemonDetail implements OnInit {
  pokemon = signal<Pokemon | null>(null);

  constructor(
    private route: ActivatedRoute,
    private pokemonService: PokemonService
  ) {}

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      const id = Number(idParam);
      this.pokemonService.getById(id).subscribe(data => {
        this.pokemon.set(data);
      });
    }
  }
}