import { Component, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { PokemonService } from '../services/pokemon.service';
import { Pokemon } from '../models/pokemon.model';

@Component({
  selector: 'app-pokemon-list',
  imports: [RouterLink],
  templateUrl: './pokemon-list.html',
  styleUrl: './pokemon-list.css',
})
export class PokemonList implements OnInit {
  pokemons = signal<Pokemon[]>([]);

  constructor(private pokemonService: PokemonService) {}

  ngOnInit(): void {
    this.pokemonService.getAll().subscribe(data => {
      this.pokemons.set(data);
    });
  }
}