import type { DashboardData } from '../../../data/dataTypes'

export interface MoveableBlock {
  source: HTMLDivElement
  collisionDiv?: HTMLDivElement
  deltaX: number
  deltaY: number
  originLeft: number
  originTop: number
}
export interface Vector2 {
  x: number
  y: number
}

export interface Block<T> {
  div: HTMLDivElement
  source: T
}

export interface DashboardDragState {
  source: Block<DashboardData>
  collision?: Block<DashboardData>

  position: Vector2
  deltaPosition: Vector2
}
