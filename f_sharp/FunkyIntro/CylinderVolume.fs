module CylinderVolume
open System

let circleSurface r = Math.PI * r * r
let multiplySurfaceH s h = s * h

let cylinderVolumeSuperPosition = circleSurface >> multiplySurfaceH
let cylinderVolumeCurry r h = (circleSurface r) * h