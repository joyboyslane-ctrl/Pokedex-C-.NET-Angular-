export interface PokeType {
  id: number;
  name: string;
  nameDe: string | null;
}

export interface Pokemon {
  id: number;
  name: string;
  nameDe: string | null;
  spriteUrl: string | null;
  shinySpriteUrl: string | null;
  cryUrl: string | null;
  heightDm: number;
  weightHg: number;
  generation: number;
  flavorText: string | null;
  evolvesFromId: number | null;
  types: PokeType[];
  weaknesses: string[];
}