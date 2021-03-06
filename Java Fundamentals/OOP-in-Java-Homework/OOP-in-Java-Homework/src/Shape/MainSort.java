package Shape;

import Shape.PlaneShape.Circle;
import Shape.PlaneShape.Rectangle;
import Shape.PlaneShape.Triangle;
import Shape.SpaceShape.Cuboid;
import Shape.SpaceShape.Sphere;
import Shape.SpaceShape.SquarePyramid;
import Shape.interfaces.AreaMeasurable;
import Shape.interfaces.PerimeterMeasurable;
import Shape.interfaces.VolumeMeasurable;

import java.util.Arrays;

/**
 * Created by ivailojordanov on 11/1/15.
 */
public class MainSort {
    public static void main(String[] args) {

        AreaMeasurable[] shapes = new AreaMeasurable[]{
                new Circle(5, 8, 12),
                new Rectangle(3, 7, 10, 5),
                new Rectangle(-1.5, 0, 2, 6),
                new Circle(0, 0, 2.5),
                new Circle(5, 8, 12),
                new Rectangle(3, 7, 10, 5),
                new Rectangle(-1.5, 0, 2, 6),
                new Circle(0, 0, 2.5),
                new Cuboid(2.5, 3.2, 1.85, 1, 2, 3),
                new Sphere(1, 2, 3, 6),
                new Cuboid(4, 5, 6, 1, 2, 3),
                new SquarePyramid(5, 6, 7, 3, 4),
                new Triangle(1, 2, 3, 4, 11, 6),
                new Rectangle(3, 7, 10, 5),
                new Circle(120, 75, 17.5)
        };
        // Sort the shapes descending by their area
        Arrays.sort(shapes, (s1, s2) ->
                -Double.compare(s1.getArea(), s2.getArea()));
        printShapes(shapes);
        System.out.println();
        VolumeMeasurable[] spaceShapes = new VolumeMeasurable[]{
                new Sphere(1, 2, 3, 6),
                new Cuboid(4, 5, 6, 1, 2, 3),
                new SquarePyramid(10, 6, 7, 15, 4),
                new Sphere(1, 4, 3, 8),
                new Cuboid(4, 10, 6, 1, 6, 3),
                new SquarePyramid(3, 6, 7, 20, 4)
        };
        // Sort the shapes descending by their volume and prints only the shapes with volume larger than 40
        Arrays.stream(spaceShapes).filter(s -> s.getVolume() > 40).sorted((s1, s2) ->
                -Double.compare(s1.getVolume(), s2.getVolume()))
                .forEach(shape -> {
                    System.out.println(shape);
                });
        System.out.println();

        PerimeterMeasurable[] planeShapes = new PerimeterMeasurable[]{
                new Circle(5, 8, 12),
                new Triangle(1, 2, 3, 4, 11, 6),
                new Rectangle(3, 7, 10, 5),
                new Circle(120, 75, 17.5),
        };
        // Sort the shapes ascending by their perimeter and prints only the shapes with volume larger than 25
        Arrays.stream(planeShapes).filter(s -> s.getPerimeter() > 25).sorted((s1, s2) ->
                -Double.compare(s1.getPerimeter(), s2.getPerimeter()))
                .forEach(shape -> {
                    System.out.println(shape);
                });
        System.out.println();
    }

    private static void printShapes(AreaMeasurable[] shapes) {
        Arrays.stream(shapes)
                .forEach(shape -> {
                    System.out.println(shape);
                });
    }
}
