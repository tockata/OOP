import interfaces.VolumeMeasurable;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

public class Test {
    public static void main(String[] args) {
        ArrayList<Vertex> vertices1 = new ArrayList<Vertex>();
        vertices1.add(new Vertex(45, 15));
        vertices1.add(new Vertex(35, 10));
        vertices1.add(new Vertex(1.5, 15.5));

        ArrayList<Vertex> vertices2 = new ArrayList<Vertex>();
        vertices2.add(new Vertex(45, 15));

        ArrayList<Vertex> vertices3 = new ArrayList<Vertex>();
        vertices3.add(new Vertex(45, 15, 2));

        Triangle triangle = new Triangle(vertices1);
        Rectangle rectangle = new Rectangle(vertices2, 45, 2.5);
        Circle circle = new Circle(vertices2, 2.5);
        SquarePyramid squarePyramid = new SquarePyramid(vertices3, 10, 10);
        Cuboid cuboid = new Cuboid(vertices3, 1, 1, 1);
        Sphere sphere = new Sphere(vertices3, 10);

        Shape[] shapes = new Shape[]{triangle, rectangle, circle, squarePyramid, cuboid, sphere};

        for (Shape shape : shapes) {
            System.out.println(shape + "\n");
        }

        //Filter and print shapes by Volume:
        List<Shape> filteredShapesByVolume =
                Arrays.asList(shapes).stream()
                        .filter(sh -> sh instanceof VolumeMeasurable)
                        .filter(sh -> ((SpaceShape)sh).getVolume() > 40)
                        .collect(Collectors.toList());
        
        System.out.println("Filtered spaceShapes by Volume size greater than 40:");
        for (Shape shape : filteredShapesByVolume) {
            System.out.println(shape);
        }
        System.out.println();

        List<Shape> planeShapes =
                Arrays.asList(shapes).stream()
                .filter(sh -> sh instanceof PlaneShape)
                .collect(Collectors.toList());

        planeShapes.sort(new Comparator<Shape>() {
            @Override
            public int compare(Shape o1, Shape o2) {
                return Double.compare(
                        (((PlaneShape) o1).getPerimeter()),
                        (((PlaneShape)o2).getPerimeter()));
            }
        });

        System.out.println("Filtered planeShapes by Perimeter:");
        for (Shape planeShape : planeShapes) {
            System.out.println(planeShape);
        }
    }
}
