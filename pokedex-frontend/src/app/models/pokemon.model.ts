export interface PokeType {
  id: number;
  name: string;
  nameDe: string | null;
}

export interface Weakness {
  name: string;
  nameDe: string;
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
  flavorTextEn: string | null;
  evolvesFromId: number | null;
  types: PokeType[];
  weaknesses: Weakness[];
}