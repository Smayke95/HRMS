import 'package:flutter/material.dart';
import 'package:hrms/providers/employee_provider.dart';

class DashboardScreen extends StatelessWidget {
  DashboardScreen({super.key}){
    var test = EmployeeProvider();
    test.getAll();
  }

  @override
  Widget build(BuildContext context) {
    return Center(
      child: SizedBox(
        width: double.infinity,
        child: Wrap(
          alignment: WrapAlignment.spaceAround,
          spacing: 40,
          runSpacing: 60,
          children: [
            Card(
                color: Colors.white,
                child: SizedBox(
                  width: 200,
                  height: 200,
                  child: Column(
                    children: [
                      const SizedBox(height: 10),
                      Container(
                        decoration: BoxDecoration(
                            border: Border.all(
                              color: Colors.grey,
                            ),
                            borderRadius: BorderRadius.circular(50)),
                        child: const SizedBox(
                          width: 100,
                          height: 100,
                          child: Icon(
                            Icons.content_paste,
                            size: 40,
                          ),
                        ),
                      ),
                      const SizedBox(height: 10),
                      const Text("Zadaci"),
                      const SizedBox(height: 10),
                      ElevatedButton(
                        child: const Text("OTVORI"),
                        onPressed: () {},
                      )
                    ],
                  ),
                )),
            Card(
                color: Colors.white,
                child: SizedBox(
                  width: 200,
                  height: 200,
                  child: Column(
                    children: [
                      const SizedBox(height: 10),
                      Container(
                        decoration: BoxDecoration(
                            border: Border.all(
                              color: Colors.grey,
                            ),
                            borderRadius: BorderRadius.circular(50)),
                        child: const SizedBox(
                          width: 100,
                          height: 100,
                          child: Icon(
                            Icons.content_paste,
                            size: 40,
                          ),
                        ),
                      ),
                      const SizedBox(height: 10),
                      const Text("Zadaci"),
                      const SizedBox(height: 10),
                      ElevatedButton(
                        child: const Text("OTVORI"),
                        onPressed: () {},
                      )
                    ],
                  ),
                )),
            Card(
                color: Colors.white,
                child: SizedBox(
                  width: 200,
                  height: 200,
                  child: Column(
                    children: [
                      const SizedBox(height: 10),
                      Container(
                        decoration: BoxDecoration(
                            border: Border.all(
                              color: Colors.grey,
                            ),
                            borderRadius: BorderRadius.circular(50)),
                        child: const SizedBox(
                          width: 100,
                          height: 100,
                          child: Icon(
                            Icons.content_paste,
                            size: 40,
                          ),
                        ),
                      ),
                      const SizedBox(height: 10),
                      const Text("Zadaci"),
                      const SizedBox(height: 10),
                      ElevatedButton(
                        child: const Text("OTVORI"),
                        onPressed: () {},
                      )
                    ],
                  ),
                )),
            Card(
                color: Colors.white,
                child: SizedBox(
                  width: 200,
                  height: 200,
                  child: Column(
                    children: [
                      const SizedBox(height: 10),
                      Container(
                        decoration: BoxDecoration(
                            border: Border.all(
                              color: Colors.grey,
                            ),
                            borderRadius: BorderRadius.circular(50)),
                        child: const SizedBox(
                          width: 100,
                          height: 100,
                          child: Icon(
                            Icons.content_paste,
                            size: 40,
                          ),
                        ),
                      ),
                      const SizedBox(height: 10),
                      const Text("Zadaci"),
                      const SizedBox(height: 10),
                      ElevatedButton(
                        child: const Text("OTVORI"),
                        onPressed: () {},
                      )
                    ],
                  ),
                )),
            Card(
                color: Colors.white,
                child: SizedBox(
                  width: 200,
                  height: 200,
                  child: Column(
                    children: [
                      const SizedBox(height: 10),
                      Container(
                        decoration: BoxDecoration(
                            border: Border.all(
                              color: Colors.grey,
                            ),
                            borderRadius: BorderRadius.circular(50)),
                        child: const SizedBox(
                          width: 100,
                          height: 100,
                          child: Icon(
                            Icons.content_paste,
                            size: 40,
                          ),
                        ),
                      ),
                      const SizedBox(height: 10),
                      const Text("Zadaci"),
                      const SizedBox(height: 10),
                      ElevatedButton(
                        child: const Text("OTVORI"),
                        onPressed: () {},
                      )
                    ],
                  ),
                )),
            Card(
                color: Colors.white,
                child: SizedBox(
                  width: 200,
                  height: 200,
                  child: Column(
                    children: [
                      const SizedBox(height: 10),
                      Container(
                        decoration: BoxDecoration(
                            border: Border.all(
                              color: Colors.grey,
                            ),
                            borderRadius: BorderRadius.circular(50)),
                        child: const SizedBox(
                          width: 100,
                          height: 100,
                          child: Icon(
                            Icons.content_paste,
                            size: 40,
                          ),
                        ),
                      ),
                      const SizedBox(height: 10),
                      const Text("Zadaci"),
                      const SizedBox(height: 10),
                      ElevatedButton(
                        child: const Text("OTVORI"),
                        onPressed: () {},
                      )
                    ],
                  ),
                )),
          ],
        ),
      ),
    );
  }
}
