import 'package:flutter/material.dart';

class DashboardScreen extends StatelessWidget {
  const DashboardScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return Center(
      child: Container(
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
                        SizedBox(height: 10),
                        Container(
                          decoration: BoxDecoration(
                              border: Border.all(
                                color: Colors.grey,
                              ),
                              borderRadius: BorderRadius.circular(50)),
                          child: SizedBox(
                            width: 100,
                            height: 100,
                            child: Icon(Icons.content_paste, size: 40,),
                          ),
                        ),
                        SizedBox(height: 10),
                        Text("Zadaci"),
                        SizedBox(height: 10),
                        ElevatedButton(
                          child: Text("OTVORI"),
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
                        SizedBox(height: 10),
                        Container(
                          decoration: BoxDecoration(
                              border: Border.all(
                                color: Colors.grey,
                              ),
                              borderRadius: BorderRadius.circular(50)),
                          child: SizedBox(
                            width: 100,
                            height: 100,
                            child: Icon(Icons.content_paste, size: 40,),
                          ),
                        ),
                        SizedBox(height: 10),
                        Text("Zadaci"),
                        SizedBox(height: 10),
                        ElevatedButton(
                          child: Text("OTVORI"),
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
                        SizedBox(height: 10),
                        Container(
                          decoration: BoxDecoration(
                              border: Border.all(
                                color: Colors.grey,
                              ),
                              borderRadius: BorderRadius.circular(50)),
                          child: SizedBox(
                            width: 100,
                            height: 100,
                            child: Icon(Icons.content_paste, size: 40,),
                          ),
                        ),
                        SizedBox(height: 10),
                        Text("Zadaci"),
                        SizedBox(height: 10),
                        ElevatedButton(
                          child: Text("OTVORI"),
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
                        SizedBox(height: 10),
                        Container(
                          decoration: BoxDecoration(
                              border: Border.all(
                                color: Colors.grey,
                              ),
                              borderRadius: BorderRadius.circular(50)),
                          child: SizedBox(
                            width: 100,
                            height: 100,
                            child: Icon(Icons.content_paste, size: 40,),
                          ),
                        ),
                        SizedBox(height: 10),
                        Text("Zadaci"),
                        SizedBox(height: 10),
                        ElevatedButton(
                          child: Text("OTVORI"),
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
                        SizedBox(height: 10),
                        Container(
                          decoration: BoxDecoration(
                              border: Border.all(
                                color: Colors.grey,
                              ),
                              borderRadius: BorderRadius.circular(50)),
                          child: SizedBox(
                            width: 100,
                            height: 100,
                            child: Icon(Icons.content_paste, size: 40,),
                          ),
                        ),
                        SizedBox(height: 10),
                        Text("Zadaci"),
                        SizedBox(height: 10),
                        ElevatedButton(
                          child: Text("OTVORI"),
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
                        SizedBox(height: 10),
                        Container(
                          decoration: BoxDecoration(
                              border: Border.all(
                                color: Colors.grey,
                              ),
                              borderRadius: BorderRadius.circular(50)),
                          child: SizedBox(
                            width: 100,
                            height: 100,
                            child: Icon(Icons.content_paste, size: 40,),
                          ),
                        ),
                        SizedBox(height: 10),
                        Text("Zadaci"),
                        SizedBox(height: 10),
                        ElevatedButton(
                          child: Text("OTVORI"),
                          onPressed: () {},
                        )
                      ],
                    ),
                  )),
            ],
          ),
        ),
      ),
    );
  }
}
